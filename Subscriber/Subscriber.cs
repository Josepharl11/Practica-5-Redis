using System;
using StackExchange.Redis;

public class Program
{
    private static readonly ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("redis-17444.c74.us-east-1-4.ec2.redns.redis-cloud.com:17444,password=9CBRHV4I2Um7oAZQ9jKF5SlUI5ciq3Sy");
    private static readonly ISubscriber sub = redis.GetSubscriber();

    public static void Main()
    {
        try
        {
            Console.WriteLine("Suscrito al canal 'test-channel'...");

            sub.Subscribe("test-channel", (channel, message) => {
                Console.WriteLine($"Mensaje recibido: {message}");
            });

            Console.WriteLine("Presiona 'Ctrl + C' para salir del suscriptor...");
            while (true)
            {
                // Solo para mantener la aplicación corriendo
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en el suscriptor: {ex.Message}");
        }
    }
}