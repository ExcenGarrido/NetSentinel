using System.Net.NetworkInformation;
using System.IO;


namespace NetSentinel
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Ping centinela = new Ping();
            string ipObjetivo = "";
            Console.WriteLine("Ingrese la IP o dominio a auditar:");
            ipObjetivo = Console.ReadLine();

            PingReply respuesta = centinela.Send(ipObjetivo);

            if (respuesta.Status == IPStatus.Success)
            {
                Console.WriteLine("El Host responde perfectamente. Latencia:" + respuesta.RoundtripTime + "ms.");

            }
            else
            {
                Console.WriteLine(" ¡ALERTA! el Host esta Caido.");

                string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string archivoLog = Path.Combine(rutaEscritorio, "Log_Alertas.txt");

               
                try
                {
                    if (!File.Exists(archivoLog))
                    {
                        File.WriteAllText(archivoLog, "--- INICIO DE AUDITORIA DE RED ---\n");
                    }

                    File.AppendAllText(archivoLog, "Falla detectada en: " + ipObjetivo + "\n");
                    Console.WriteLine("Se guardó y actualizo el Log de evidencia en tu Escritorio.");
                }
                catch (Exception error)
                {
                    Console.WriteLine("No se pudo guardar el Log. Windows lo bloqueó: " + error.Message);
                }


                Console.ReadLine();



            }
        }
    }
}
