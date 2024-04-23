using System.Text;
using DesafioProjetoHospedagem.Models;
using Newtonsoft.Json;

Console.OutputEncoding = Encoding.UTF8;
List<Pessoa> hospedes = new List<Pessoa>();
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 3, valorDiaria: 30);
Console.Write("Insira a quantidade de hospedes: ");
int QuantidadeHospedes = int.Parse(Console.ReadLine());

for(int i = 0; i < QuantidadeHospedes; i++)
{
    Console.Write($"Insira o nome do {i + 1}# Hospede: ");
    string nome = Console.ReadLine();
    Pessoa p = new Pessoa(nome);
    hospedes.Add(p);
}
  
    
    Console.WriteLine("--------------------");
    Console.WriteLine($"{suite}");
    Console.WriteLine("--------------------");
    Console.WriteLine("");
    Console.Write("Insira a quantidade de dias: ");
    int Dias = int.Parse(Console.ReadLine());
    Reserva Reserva = new Reserva(Dias, suite, hospedes);
    string SerializarReserva = JsonConvert.SerializeObject(Reserva, Formatting.Indented);
    File.WriteAllText("Models/ReservaHospede.json", SerializarReserva);
    Reserva.CadastrarSuite(suite);     
    Reserva.CadastrarHospedes(hospedes);
    Console.Clear();

Console.WriteLine($"Hóspedes: {Reserva.ObterQuantidadeHospedes()}");
Console.WriteLine();
Console.WriteLine($"Valor Total: {Reserva.CalcularValorDiaria()}");
Console.WriteLine();
foreach(var pessoas in hospedes) 
{
Console.WriteLine($"Nome Hospedes: {pessoas}");
}