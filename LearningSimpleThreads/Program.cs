using System;
using System.Threading;

namespace LearningSimpleThreads
{
  class Program
  {
    /// <summary>
    /// Exemplo de bloco a ser executado (Procedimento)
    /// </summary>
    public static void ThreadProcedure()
    {
      for (int i = 0; i < 10; i++)
      {
        Console.WriteLine($"Thread secundária: {i}");
        Thread.Sleep(500);
      }
    }

    /// <summary>
    /// Thread Principal
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      Console.WriteLine("Thread principal: Inicia uma nova Thread");

      // Criando uma nova Thread
      Thread t = new Thread(new ThreadStart(ThreadProcedure));
      t.Start(); // Ele começa a funcionar paralelamente

      // Ações da Thread Principal
      for (int i = 0; i<5; i++)
      {
        Console.WriteLine("-----------------------------------");
        Thread.Sleep(500);
      }

      t.Join(); // Main Thread espera a t (Thread) finalizar para depois continuar executando

      Console.WriteLine("Aperte enter para finalizar");
      Console.ReadLine();
    }
  }
}
