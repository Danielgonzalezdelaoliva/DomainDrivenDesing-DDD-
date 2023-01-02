using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;
using Delgado.Ddd.KernellCompartido.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Delgado.Ddd.Recepcion.Infraestructura.Datos
{
    public class RepositorioCache<T> : IRepositorioDeLectura<T> where T : class, IRaizDeAgregado
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<RepositorioCache<T>> _logger;
        private readonly RepositorioEf<T> _repositorioDeOrigen;
        private MemoryCacheEntryOptions _opcionesCache;

        public RepositorioCache(IMemoryCache cache, ILogger<RepositorioCache<T>> logger, RepositorioEf<T> repositorioDeOrigen, MemoryCacheEntryOptions opcionesCache)
        {
            _cache = cache;
            _logger = logger;
            _repositorioDeOrigen = repositorioDeOrigen;
            _opcionesCache = opcionesCache;
        }

        public Task<T> AddAsync(T entity)
        {
            return _repositorioDeOrigen.AddAsync(entity);
        }

        public Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            return _repositorioDeOrigen.CountAsync(specification, cancellationToken);
        }

        public Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return _repositorioDeOrigen.CountAsync(cancellationToken);
        }

        public Task<T> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
        {
            string key = $"{typeof(T).Name}-{id}";
            _logger.LogInformation("Checking cache for " + key);
            return _cache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(_opcionesCache);
                _logger.LogWarning("Fetching source data for " + key);
                return _repositorioDeOrigen.GetByIdAsync(id, cancellationToken);
            });
        }

        public Task<T> GetBySpecAsync<Spec>(Spec specification, CancellationToken cancellationToken = default) where Spec : ISingleResultSpecification, ISpecification<T>
        {
            if (specification.CacheEnabled)
            {
                string key = $"{specification.CacheKey}-GetBySpecAsync";
                _logger.LogInformation("Checking cache for " + key);
                return _cache.GetOrCreate(key, entry =>
                {
                    entry.SetOptions(_opcionesCache);
                    _logger.LogWarning("Fetching source data for " + key);
                    return _repositorioDeOrigen.GetBySpecAsync(specification, cancellationToken);
                });
            }
            return _repositorioDeOrigen.GetBySpecAsync(specification);
        }

        public Task<TResult> GetBySpecAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default)
        {
            if (specification.CacheEnabled)
            {
                string key = $"{specification.CacheKey}-GetBySpecAsync";
                _logger.LogInformation("Checking cache for " + key);
                return _cache.GetOrCreate(key, entry =>
                {
                    entry.SetOptions(_opcionesCache);
                    _logger.LogWarning("Fetching source data for " + key);
                    return _repositorioDeOrigen.GetBySpecAsync(specification, cancellationToken);
                });
            }
            return _repositorioDeOrigen.GetBySpecAsync(specification, cancellationToken);
        }

        public Task<List<T>> ListAsync(CancellationToken cancellationToken = default)
        {
            string key = $"{typeof(T).Name}-List";
            _logger.LogInformation($"Checking cache for {key}");
            return _cache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(_opcionesCache);
                _logger.LogWarning($"Fetching source data for {key}");
                return _repositorioDeOrigen.ListAsync(cancellationToken);
            });
        }

        public Task<List<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
        {
            if (specification.CacheEnabled)
            {
                string key = $"{specification.CacheKey}-ListAsync";
                _logger.LogInformation($"Checking cache for {key}");
                return _cache.GetOrCreate(key, entry =>
                {
                    entry.SetOptions(_opcionesCache);
                    _logger.LogWarning($"Fetching source data for {key}");
                    return _repositorioDeOrigen.ListAsync(specification, cancellationToken);
                });
            }
            return _repositorioDeOrigen.ListAsync(specification, cancellationToken);
        }

        public Task<List<TResult>> ListAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default)
        {
            if (specification.CacheEnabled)
            {
                string key = $"{specification.CacheKey}-ListAsync";
                _logger.LogInformation($"Checking cache for {key}");
                return _cache.GetOrCreate(key, entry =>
                {
                    entry.SetOptions(_opcionesCache);
                    _logger.LogWarning($"Fetching source data for {key}");
                    return _repositorioDeOrigen.ListAsync(specification, cancellationToken);
                });
            }
            return _repositorioDeOrigen.ListAsync(specification, cancellationToken);
        }

        public Task SaveChangesAsync()
        {
            return _repositorioDeOrigen.SaveChangesAsync();
        }

        public Task UpdateAsync(T entity)
        {
            return _repositorioDeOrigen.UpdateAsync(entity);
        }
    }
}
