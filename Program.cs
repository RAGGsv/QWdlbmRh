//ragcorp.gg@gmail.com

﻿using System;
using System.IO;

namespace Agenda
{
    class Program
    {
        static StreamReader LeerArchivo;
        static StreamWriter EscribirArchivo;


        static void Main(string[] args)
        {
           
            Console.Title = "AGENDA";
            int Op;
            String Texto;
            String Dui;
            String Nombre;
            String Direccion;
            String Telefono;
            String Email;
            String ProfesionOficio;
            String cadena, bdui;
            bool encontrado;
            encontrado = false;
            String[] campos = new String[700];
            char[] separador = { ',' };
            do
            {
                Console.Clear();
                Console.WriteLine("----------------------MENU----------------------");
                Console.WriteLine("Digite 1 para crear y escribir sobre un archivo.");
                Console.WriteLine("Digite 2 para leer el texto en el archivo creado.");
                Console.WriteLine("Digite 3 para buscar por numero de DUI un registro");
                Console.WriteLine("Digite 4 para salir");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Escriba su selección:");
                Op = int.Parse(Console.ReadLine());
                {
                   
                    switch (Op)
                    {
                        case 1:
                           
                            EscribirArchivo = new StreamWriter("Agenda.txt", true);
                            Console.WriteLine("ingrese el dui");
                            Dui = Console.ReadLine();
                            Console.WriteLine("ingrese el nombre");
                            Nombre = Console.ReadLine();
                            Console.WriteLine("ingrese direccion");
                            Direccion = Console.ReadLine();
                            Console.WriteLine("ingrese Telefono");
                            Telefono = Console.ReadLine();
                            Console.WriteLine("ingrese Email");
                            Email = Console.ReadLine();
                            Console.WriteLine("ingrese Profesion u Oficio");
                            ProfesionOficio = Console.ReadLine();
                            Texto = Dui + "," + " " + Nombre + "," + " " + Direccion + "," + " " + Telefono + "," + " " + Email + "," + " " + ProfesionOficio;
                            EscribirArchivo.WriteLine(Texto);
                            Console.WriteLine("Escritura en archivo exitosa.");
                            EscribirArchivo.Close();
                            break;

                        case 2:
                            Console.Clear();
                            LeerArchivo = File.OpenText("Agenda.txt");
                            Console.WriteLine("\nTEXTO ALMACENADO EN EL ARCHIVO");
                            Console.WriteLine("------------------------------------------------");
                            cadena = LeerArchivo.ReadLine();
                            while (cadena != null)
                            {
                                campos = cadena.Split(separador);
                                Console.WriteLine("DUI: " + campos[0].Trim());
                                Console.WriteLine("Nombre: " + campos[1].Trim());
                                Console.WriteLine("Direccion: " + campos[2].Trim());
                                Console.WriteLine("Telefono: " + campos[3].Trim());
                                Console.WriteLine("Email: " + campos[4].Trim());
                                Console.WriteLine("Profesion u Oficio: " + campos[5].Trim());
                                Console.WriteLine("");
                                cadena = LeerArchivo.ReadLine();
                            }
                            Console.WriteLine("------------------------------------------------");
                            Console.WriteLine("\n\nFin mensaje en el archivo.");
                            Console.ReadKey(true);
                           
                            LeerArchivo.Close();

                            break;

                        case 3:
                            try
                            {
                                encontrado = false;
                               String[] c2 = new String[5];
                                LeerArchivo = File.OpenText("Agenda.txt");
                                Console.WriteLine("Ingresa el numero de DUI que buscas: ");
                                bdui = Console.ReadLine();
                                cadena = LeerArchivo.ReadLine();
                                while (cadena != null && encontrado == false)
                                {
                                    c2 = cadena.Split(separador);
                                    //043453690, julio galdamez, jardines, 75799598, jucegame007@gmail.com, estudiante
                                    if (c2[0].Trim().Equals(bdui))
                                    {
                                        Console.WriteLine("DUI: " + c2[0].Trim());
                                        Console.WriteLine("Nombre: " + c2[1].Trim());
                                        Console.WriteLine("Direccion: " + c2[2].Trim());
                                        Console.WriteLine("Telefono: " + c2[3].Trim());
                                        Console.WriteLine("Email: " + c2[4].Trim());
                                        Console.WriteLine("Profesion u Oficio: " + c2[5].Trim());
                                        encontrado = true;
                                    }
                                    else
                                    {
                                        cadena = LeerArchivo.ReadLine();
                                       
                                    }
                                }
                                if (encontrado == false)
                                {
                                    Console.WriteLine("El DUI " + bdui + " no se encontro");
                                }
                            
                                 }
                                 catch (FileNotFoundException fe)
                            {
                                Console.WriteLine("¡ERROR! " + fe.Message);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("¡ERROR! " + e.Message);
                            }
                            Console.WriteLine("\nPresione Enter para continuar...");
                            Console.ReadKey(true);
                            LeerArchivo.Close();
                            break;

                        default:
                            if (Op == 4) { 
                            }
                            else
                            {
                                Console.WriteLine("Ingresa una opcion Correcta");
                                Console.ReadKey(true);
                            }
                            break;
                    }
                    
                  

                }
               

            } while (Op != 4);


        }
    }
}
