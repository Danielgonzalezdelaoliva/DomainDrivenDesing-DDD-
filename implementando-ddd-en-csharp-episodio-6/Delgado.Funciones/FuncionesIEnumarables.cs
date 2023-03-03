namespace Delgado.Funciones;

/// <summary>
/// Estos valores son executados en el procesador
/// Diferente que queries que son ejecutados en la base de datos
/// </summary>
public class FuncionesIEnumarables
{
    private readonly IEnumerable<int> Numeros;

    public FuncionesIEnumarables(List<int> numeros)
    {
        Numeros = numeros;
    }

    //Delegate Func regresa un valor. Por ejemplo bool
    Func<int, bool> NumerosIgualesA1 = x => x == 1;    
    Func<int, bool> NumerosEntreTresYDiez = x => x >= 3 && x <= 10;
    

    //Delegate Action No regresa valor. Solo ejectua accion usando parametro opcional
    //Action<string> ImprimirSaludosConParametro = nombre => { Console.WriteLine($"Hola {nombre}"); };
    //Action ImprimirSaludo = () => Console.WriteLine("Hola!");

    public IEnumerable<int> ListarNumerosUnoUsandoExpresionLambda()
    {
        //Lambda: () => expression
        //Lambda: parametro => parametro == 1

        return Numeros.Where(x => x == 1);
    }

    public IEnumerable<int> ListarNumerosUnoUsandoDelegate()
    {
        // Any lambda expression can be converted to a delegate type
        // Lambda Expression: parametro => parametro == 1
        // Delegate: Func<parametro,respuesta> NombreDeFuncion = parametro => parametro == 1
        // Delegate: Func<int, bool> EsIgual1 = x => x == 1;                
        return Numeros.Where(NumerosIgualesA1);
    }

    public IEnumerable<int> ListarNumerosEntreTresYDiezUsandoExpresionLambda()
    {
        return Numeros.Where(n => n >= 3 && n <= 10);
    }

    public IEnumerable<int> ListarNumerosEntreTresYDiezUsandoDelegate()
    {
        return Numeros.Where(NumerosEntreTresYDiez);
    }

    public IEnumerable<int> ListarNumeros1YEntre3Y10()
    {
        return Numeros.Where(x => NumerosIgualesA1(x) && NumerosEntreTresYDiez(x));
    }

}