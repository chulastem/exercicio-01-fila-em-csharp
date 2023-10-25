using System;
using System.Collections.Generic;
using System.Threading;

namespace fila;
public class Program
{
    static void Main()
    {

        //Definindo o número total de clinetes e funcionários
        int numeroClientes = 10;
        int numeroFuncionarios = 3;

        //Iniciando a fila de clientes
        Queue<Cliente> filaEspera = new Queue<Cliente>();
        for (int i = 1; i <= numeroClientes; i++)
        {
            Cliente cliente = new Cliente
            {
                Numero = i,
                //função para definir um tempo aleatorio de atendimento (de 1 a 6 sec)
                TempoAtendimento = new Random().Next(1, 6)
            };
            filaEspera.Enqueue(cliente);
            Console.WriteLine($"{DateTime.Now} | Cliente {i} entrou na fila de espera.");
        }
        //Criando uma lista de funcionários para realizar o atendimento.
        //Ultiliza-se a LISTA 
        List<Funcionario> funcionarios = new List<Funcionario>();
        for (int i = 1; i <= numeroFuncionarios; i++)
        {
            //Verificando se o funcionário está "Ocupado" (0,1)
            funcionarios.Add(new Funcionario { Numero = i, Ocupado = false });
        }

        while (filaEspera.Count > 0)
        {
            for (int i = 0; i < funcionarios.Count; i++)
            {
                if (!funcionarios[i].Ocupado && filaEspera.Count > 0)
                {
                    Cliente cliente = filaEspera.Dequeue();
                    funcionarios[i].Ocupado = true;
                    Console.WriteLine($"\n{DateTime.Now} | Atendendo Cliente {cliente.Numero}...");
                    Thread.Sleep(cliente.TempoAtendimento * 1000);
                    Console.WriteLine($"{DateTime.Now} | Cliente {cliente.Numero} atendido pelo funcionário: {funcionarios[i].Numero} com o tempo de {cliente.TempoAtendimento} segundos.");
                    funcionarios[i].Ocupado = false;
                }
                
            }
        }
        Console.WriteLine($"\n{DateTime.Now} |Todos os clientes foram atendidos.");
        Console.ReadLine();
    }
}
