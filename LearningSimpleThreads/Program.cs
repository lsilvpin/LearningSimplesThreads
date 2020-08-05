using System;
using System.Threading;

namespace LearningSimpleThreads
{
  class Program
  {
    // Variável compartilhada para finalizar a Thread t corretamente
    private static bool stopped = false;

    [ThreadStatic] // Faz com que cada Thread tenha sua própria cópia do atributo
    public static string Message;

    /// <summary>
    /// Exemplo de bloco a ser executado (Procedimento)
    /// </summary>
    public static void ThreadProcedure(Object o)
    {
      // Ambas as Threads tem uma cópia da variável Message
      Message = "Wooopie" + " __ Thread " + Convert.ToString(o);

      while (!stopped)
      {
        Console.WriteLine(Message + " running ...");
        Thread.Sleep(1000);
      }
    }

    /// <summary>
    /// Thread Principal
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      Console.WriteLine("Aperte qualquer tecla para finalizar");

      // Criando uma nova Thread
      Thread t_1 = new Thread(new ParameterizedThreadStart(ThreadProcedure));
      t_1.Start(1);

      // Criando mais uma Thread
      Thread t_2 = new Thread(new ParameterizedThreadStart(ThreadProcedure));
      t_2.Start(2);

      Console.ReadKey();
      stopped = true;
      t_1.Join();
      t_2.Join();
    }
  }
}
