using System;
using dotnet_code_challenge.Common;
using dotnet_code_challenge.DataClients;
using dotnet_code_challenge.Services;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Setup();
            var horseService = serviceProvider.GetService<IHorseDataProcessService>();
            var horseData = horseService.GetHorseData(SortOrder.Ascending);
            foreach (var horse in horseData)
            {
                Console.WriteLine($"{horse.Name}");
            }

            Console.ReadLine();
        }

        private static ServiceProvider Setup()
        {
            return new ServiceCollection()
                .AddSingleton(typeof(IDataReadClient<>), typeof(DataReadClient<>))
                .AddSingleton(typeof(IWolferhamptonRaceClient), typeof(WolferhamptonRaceClient))
                .AddSingleton(typeof(ICaulfieldRaceClient), typeof(CaulfieldRaceClient))
                .AddSingleton(typeof(IHorseDataProcessService), typeof(HorseDataProcessService))
                .BuildServiceProvider();
        }
    }
}
