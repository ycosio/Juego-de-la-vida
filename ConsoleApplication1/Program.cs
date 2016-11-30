using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] matriz = new bool[50,50];
            bool[,] matriz2 = new bool[50, 50];
            //Llenar la matriz de muertos
            for (int f=0;f<50;f++)
            {
                for (int c=0;c<50;c++) {
                    matriz[f, c] = false;
                }
            }

            //Asignar vivos inicales
            matriz[40, 40] = true;
            matriz[40, 41] = true;
            matriz[41, 40] = true;
            matriz[41, 41] = true;
            matriz[41, 42] = true;
            matriz[40, 39] = true;

            while (true) {
                //Primer chequeo
                for (int f = 0; f < 50; f++)
                {
                    for (int c = 0; c < 50; c++)
                    {
                        bool x;
                        if (f == 40 && c==39)
                            x = matriz[40, 39];

                        //Verificar que los valores no sobrepasen la matriz
                        bool[] vector;
                        if (f == 0 && c == 0)
                            vector = new bool[3] { matriz[f, c + 1], matriz[f + 1, c + 1], matriz[f + 1, c] };
                        else if (c == 0 && f!=49)
                            vector = new bool[5] { matriz[f, c + 1], matriz[f + 1, c + 1], matriz[f + 1, c], matriz[f - 1, c + 1], matriz[f - 1, c] };
                        else if (c == 0 && f == 49)
                            vector = new bool[3] { matriz[f, c + 1], matriz[f - 1, c + 1], matriz[f - 1, c] };
                        else if (f == 0 && c!=49)
                            vector = new bool[5] { matriz[f, c - 1], matriz[f, c + 1], matriz[f + 1, c - 1], matriz[f + 1, c + 1], matriz[f + 1, c] };
                        else if (f == 0 && c == 49)
                            vector = new bool[3] { matriz[f, c - 1], matriz[f + 1, c - 1], matriz[f + 1, c] };
                        else if (f == 49 && c == 49)
                            vector = new bool[3] { matriz[f, c - 1], matriz[f - 1, c - 1], matriz[f - 1, c] };
                        else if (c == 49)
                            vector = new bool[5] { matriz[f, c - 1], matriz[f + 1, c - 1], matriz[f + 1, c], matriz[f - 1, c - 1], matriz[f - 1, c] };
                        else if (f == 49)
                            vector = new bool[5] { matriz[f, c - 1], matriz[f, c + 1], matriz[f - 1, c - 1], matriz[f - 1, c + 1], matriz[f - 1, c] };
                        else
                            vector = new bool[8] { matriz[f, c - 1], matriz[f, c + 1], matriz[f + 1, c - 1], matriz[f + 1, c + 1], matriz[f + 1, c], matriz[f - 1, c - 1], matriz[f - 1, c + 1], matriz[f - 1, c] };
                          //para cuando llega al 39,40 ya fue alterado anteriormente... se debe checar el reemplazo ya que matriz y matriz2 apuntan al mismo sitio de variable
                        //Validar las celulas vecinas
                        if (vida(matriz[f, c], vector))
                        {
                            matriz2[f, c] = true;
                            Console.Write("■");
                        }
                        else
                        {
                            matriz2[f , c] = false;
                            Console.Write(".");
                        }
                    }
                    Console.WriteLine();
                }

                //Modificar la matriz con los nuevos valores
                for (int i = 0; i < 50; i++)
                {
                    for (int j = 0; j < 50; j++)
                    {
                        matriz[i,j] = matriz2[i,j];
                    }
                }
                //Console.ReadKey();
                Thread.Sleep(1000);
                Console.Clear();
            }

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
            if (vivos < 2 && stateCell)
                return false;
            else if (((vivos == 2) || (vivos == 3)) && stateCell==true)
                return true;
            else if (vivos > 3 && stateCell)
                return false;
            else if (vivos >= 3 && !stateCell)
                return true;
            else
                return false;
        }
    }
}
