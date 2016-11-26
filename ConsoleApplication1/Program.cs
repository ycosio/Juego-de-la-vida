using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] matriz = new bool[50,50];
            //Llenar la matriz de muertos
            for(int f=0;f<50;f++)
            {
                for (int c=0;c<50;c++) {
                    matriz[f, c] = false;
                }
            }

            //Asignar vivos inicales
            matriz[40, 40]=true;
            matriz[40, 41] = true;
            matriz[41, 40] = true;
            matriz[41, 41] = true;

            //Hacer While infinito {
                //Primer chequeo
                for (int f = 0; f < 50; f++)
                {
                    for (int c = 0; c < 50; c++)
                    {
                        //Verificar que los valores no sobrepasen la matriz
                        bool[] vector = new bool[8];
                        if (f==0 && c==0)
                            vector = { matriz[f, c - 1], matriz[f, c + 1], matriz[f + 1, c - 1], matriz[f + 1, c + 1], matriz[f + 1, c], matriz[f - 1, c - 1], matriz[f - 1, c + 1], matriz[f - 1, c] };
                        else if(c==0)
                            vector = { matriz[f, c - 1], matriz[f, c + 1], matriz[f + 1, c - 1], matriz[f + 1, c + 1], matriz[f + 1, c], matriz[f - 1, c - 1], matriz[f - 1, c + 1], matriz[f - 1, c] };
                        else if (f == 0)
                            vector = { matriz[f, c - 1], matriz[f, c + 1], matriz[f + 1, c - 1], matriz[f + 1, c + 1], matriz[f + 1, c], matriz[f - 1, c - 1], matriz[f - 1, c + 1], matriz[f - 1, c] };
                        else
                            vector = { matriz[f, c - 1], matriz[f, c + 1], matriz[f + 1, c - 1], matriz[f + 1, c + 1], matriz[f + 1, c], matriz[f - 1, c - 1], matriz[f - 1, c + 1], matriz[f - 1, c] };
                    
                        //Validar las celular vecinas
                        if (vida(matriz[f,c],vector))
                            Console.Write("*");
                        else
                            Console.Write(".");
                    }
                    Console.WriteLine();

                    //Modificar la matriz con los nuevos valores
                }
            //}
            Console.ReadKey();
        }

        static bool vida(bool stateCell, bool[] cells)
        {
            int vivos = 0;

            //Contar muertos y vivos
            for (int cell = 0; cell < cells.Length; cell++)
            {
                if (cells[cell])
                    vivos++;
            }

            //Reglas
            if (vivos < 2)
                return false;
            else if ((vivos == 2) || (vivos == 3))
                return true;
            else if (vivos > 3 && stateCell)
                return false;
            else
                return true;
        }
    }
}
