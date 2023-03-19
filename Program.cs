/// Desenvolva um algoritmo que:
/// - Leia 2 matrizes 3x2 de números inteiros.
/// - Organize os números em ordem crescente.
/// - Crie uma matriz 3x4 com os números ordenados anteriormente.
Console.Title = "Algoritmo Sposito";
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("EP1 - Atividade Prática de Aprendizagem 01 - EXAME\n");
Console.Write("Utilizando aplicação console ");
Console.ForegroundColor = ConsoleColor.Magenta;
Console.Write(".NET core 6.0\n\n");
Console.ResetColor();

List<int> list = new();
string[,] matriz1 = new string[3, 2];
string[,] matriz2 = new string[3, 2];
string[] foi = new string[2];
bool to3 = false;
Random rndx = new Random();
int[] rnd6 = new int[2] { rndx.Next(1, 7), rndx.Next(1, 7) };


List<int> listNumbers = new List<int>();

//Gerar tabela matriz
Console.Write(" Matrizes geradas randomicamente:\n\n  Matriz 1               Matriz 2\n"+
              " ╔════════╗             ╔════════╗\n");
for (int i = 0; i < 3; i++)
{
    if (i == 0)
    {
        Console.SetCursorPosition(1, !to3 ? 8 : 9);
        Console.Write("║");
        Console.SetCursorPosition(10, !to3 ? 8 : 9);
        Console.Write("║");
    }
    if (i == 2)
    {
        Console.SetCursorPosition(24, !to3 ? 8 : 9);
        Console.Write("║");
        Console.SetCursorPosition(33, !to3 ? 8 : 9);
        Console.Write("║");
    }
    Random rnd = new();

    //Matriz 1
    if ((!to3 ? i : i + 2) + (!to3 ? 1 : 2) == rnd6[0])
    {
        matriz1[i, !to3 ? 0 : 1] = " X";
        Console.ForegroundColor = ConsoleColor.Green;
    }
    else
    {
        matriz1[i, !to3 ? 0 : 1] = RepeatNumber(rnd, listNumbers).ToString();
        matriz1[i, !to3 ? 0 : 1] = matriz1[i, !to3 ? 0 : 1].Length == 1 ? " " + matriz1[i, !to3 ? 0 : 1] : matriz1[i, !to3 ? 0 : 1];
        list.Add(Int32.Parse(matriz1[i, !to3 ? 0 : 1]));
    }
    Console.SetCursorPosition(3 * i + 2, !to3 ? 8 : 9);
    Console.Write(matriz1[i, !to3 ? 0 : 1]);
    Console.ResetColor();
    
    
    //Matriz 2
    if ((!to3 ? i : i + 2) + (!to3 ? 1 : 2) == rnd6[1])
    {
        matriz2[i, !to3 ? 0 : 1] = " Y";
        Console.ForegroundColor = ConsoleColor.Yellow;
    }
    else
    {
        matriz2[i, !to3 ? 0 : 1] = RepeatNumber(rnd, listNumbers).ToString();
        matriz2[i, !to3 ? 0 : 1] = matriz2[i, !to3 ? 0 : 1].Length == 1 ? " " + matriz2[i, !to3 ? 0 : 1] : matriz2[i, !to3 ? 0 : 1];
        list.Add(Int32.Parse(matriz2[i, !to3 ? 0 : 1]));
    }
    
    Console.SetCursorPosition(23 + 3 * i + 2, !to3 ? 8 : 9);
    Console.Write(matriz2[i, !to3 ? 0 : 1]);
    Console.ResetColor();
    
    if (i == 2 && !to3)
    {
        to3 = true;
        i = -1;
    }
}
Console.WriteLine("\n ╚════════╝             ╚════════╝");
Console.Write("Digite dois valores não repetidos de 0 a 99 para ");
Console.ForegroundColor = ConsoleColor.Green;
Console.Write("X");
Console.ResetColor();
Console.Write(" e ");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.Write("Y");
Console.ResetColor();
Console.Write(".\n\n");
Here1:

foi = RunReadKey(false).Split(' ');

foreach (string s in foi)
{
    
    to3 = false;
    for (int i = 0; i < 3; i++)
    {
        //if (foi.Length == 2 && foi[0] == foi[1] || s == matriz1[i, !to3 ? 0 : 1].Replace(" ", "") || s == matriz2[i, !to3 ? 0 : 1].Replace(" ", ""))
        if (foi.Length == 2 && foi[0] == foi[1] || s == matriz1[i, !to3 ? 0 : 1].Replace(" ", "") || s == matriz2[i, !to3 ? 0 : 1].Replace(" ", ""))
        {
            Repetido(true);
            goto Here1;
        }
        if (i == 2 && !to3)
        {
            to3 = true;
            i = -1;
        }
    }
}

for (int m = 0; m <= 1; m++)
{
    if (m == 1 && foi.Length == 1)
    {
        Console.SetCursorPosition(0, 11);
        Console.Write("Digite um valor não repetido de 0 a 99 para ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Y");
        Console.ResetColor();
        Console.Write(".         \n\n");
        Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
    Here2:
        foi = RunReadKey(true, foi[0]).Split(' ');

        for (int i = 0; i < 3; i++)
        {
            if (foi.Length == 2 && foi[0] == foi[1] || foi[1] == matriz1[i, !to3 ? 0 : 1].Replace(" ", "") || foi[1] == matriz2[i, !to3 ? 0 : 1].Replace(" ", ""))
            {
                Repetido(false);
                to3 = false;
                goto Here2;
            }
            if (i == 2 && !to3)
            {
                to3 = true;
                i = -1;
            }
        }
    }
    SetNumbColor(m, rnd6[m], foi[m]);
    list.Add(Int32.Parse(foi[m]));
}

//PROXIMO PASSO GERAR A MATRIZ 4X3 EM ORDEM NUMERICA
int k = 0;
int f = 0;

list.Sort();
Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
Console.WriteLine(" Nova matriz de 4x3 gerada em ordem numerica.");
Console.WriteLine("           ╔═══════════╗");
for(int i = 0; i <= 3; i++)
{
    if (i == 0) Console.Write("           ║");
    Console.Write((list[f].ToString().Length == 1 ? " " + list[f] : list[f]) + (i == 3 ? null : " "));
    if (i == 3) Console.Write("║");

    //(foi.Length == 2 && foi[0] == foi[1] || foi[1] == matriz1[i, !to3 ? 0 : 1].Replace(" ", "") || foi[1] == matriz2[i, !to3 ? 0 : 1].Replace(" ", ""))
    if (i == 3 && k <= 1)
    {
        Console.Write("\n");
        i = -1;
        k++;
    }
    f++;
}
Console.Write("\n           ╚═══════════╝\n");

Console.WriteLine("Digite qualquer tecla para fechar");
Console.ReadKey(true);
//FIM

static string RunReadKey(bool rpt, string? foi = null)
{
    ConsoleKeyInfo keyinfo;
    string digitos = "z";
    do
    {
        keyinfo = Console.ReadKey(true);

        if ((Char.IsNumber(keyinfo.KeyChar) && ((digitos.Contains(' ') || digitos.Length != 3) && (digitos.Contains(' ') && digitos.IndexOf(' ') != 2 || digitos.Length < 5)) ||
            (keyinfo.Key == ConsoleKey.Spacebar && digitos.Split(' ').Length - 1 == 0) && digitos.Length != 1 && rpt == false) &&
            digitos.Length <= 5)
        {
            Console.Write(keyinfo.KeyChar);
            digitos += keyinfo.KeyChar;
        }
        if (keyinfo.Key == ConsoleKey.Backspace && digitos.Length > 1)
        {
            Console.Write("\b \b");
            digitos = digitos.Remove(digitos.Length - 1);
        }
    }
    while (keyinfo.Key != ConsoleKey.Enter && keyinfo.Key != ConsoleKey.O || digitos.Length == 1);
    digitos = digitos.Trim('z');
    if (foi == null)
    {
        return digitos;
    }
    else
    {
        digitos = foi + " " + digitos;
        return digitos;
    }
}
static void Repetido(bool dual)
{
    Console.SetCursorPosition(0, 11);
    Console.Beep();
    if (dual == true)
    {
        Console.Write("Digite dois valores ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("não repetidos");
        Console.ResetColor();
        Console.Write(" de 0 a 99 para ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("X");
        Console.ResetColor();
        Console.Write(" e ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Y");
        Console.ResetColor();
        Console.Write($".\n\n");
    }
    else
    {
        Console.Write("Digite um valor ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("não repetido");
        Console.ResetColor();
        Console.Write(" de 0 a 99 para ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Y");
        Console.ResetColor();
        Console.Write($".\n\n");
    }
    Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
}
static int RepeatNumber(Random rnd, List<int> listNumbers)
{
    int number;
    do
    {
        number = rnd.Next(0, 99);
    } while (listNumbers.Contains(number));
    listNumbers.Add(number);
    return number;
}
static void SetNumbColor(int x, int rnd6, string foi)
{
    Console.SetCursorPosition((x == 0 ? -1 : 22) + 3 * (rnd6 <= 3 ? rnd6 : rnd6 - 3), rnd6 <= 3 ? 8 : 9);
    Console.ForegroundColor = x == 0 ? ConsoleColor.Green : ConsoleColor.Yellow;
    Console.WriteLine(foi.Length == 1 ? " " + foi : foi);
    Console.ResetColor();
    Console.SetCursorPosition(0, 13);
}