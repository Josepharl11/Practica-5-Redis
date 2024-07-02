using System;
using StackExchange.Redis;

public class Publisher
{
    private static readonly ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("redis-17444.c74.us-east-1-4.ec2.redns.redis-cloud.com:17444,password=9CBRHV4I2Um7oAZQ9jKF5SlUI5ciq3Sy");
    private static readonly ISubscriber sub = redis.GetSubscriber();

    public static void Main()
    {
        try
        {
            Console.WriteLine("Conectado a Redis...");
            Console.WriteLine("Escribe mensajes para publicar en el canal 'test-channel'. Escribe 'exit' para salir.");

            string message;
            while ((message = Console.ReadLine()) != "exit")
            {
                sub.Publish("test-channel", message);
                Console.WriteLine($"Publicado: {message}");
            }

            Console.WriteLine("Publicador finalizado.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en el publicador: {ex.Message}");
        }
    }
}