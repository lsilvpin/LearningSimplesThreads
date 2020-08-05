using System;
using System.Threading;

namespace LearningSimpleThreads
{
  class Program
  {
    // Variável compartilhada para finalizar a Thread t corretamente
    static bool stopped = false;

    /// <summary>
    /// Exemplo de bloco a ser executado (Procedimento)
    /// </summary>
    public static void ThreadProcedure()
    {
      while (!stopped)
      {
        Console.WriteLine("Running ...");
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
      Thread t = new Thread(new ThreadStart(ThreadProcedure));
      t.Start(); // Ele começa a funcionar paralelamente

      Console.ReadKey();
      stopped = true;
      t.Join();
    }
  }
}
