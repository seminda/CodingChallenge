using System;
using dotnet_code_challenge.DataClients;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = Setup();
        }

        private static ServiceProvider Setup()
        {
            return new ServiceCollection()
                .AddSingleton(typeof(IDataReadClient<>), typeof(DataReadClient<>))
                .AddSingleton(typeof(IWolferhamptonRaceClient), typeof(WolferhamptonRaceClient))
                .AddSingleton(typeof(ICaulfieldRaceClient), typeof(CaulfieldRaceClient))
                .BuildServiceProvider();
        }
    }
}
