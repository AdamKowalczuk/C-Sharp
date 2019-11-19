using System;

//Przygotuj kilka tablic do testowania: 
//    losową, uporządkowana rosnąco, uporządkowaną malejąco, stałą.
//    Zmodyfikuj kod algorytmów przez wstawianie i wybieranie z wykładu 
//    tak aby zliczać liczbę porównań i zamian(dla wstawiania właściwie przesunięć).
//Przeprowadź odpowiednie testy.
class Program
{
    static void Wybieranie(int[] L)
    {
        int porownania = 0;
        int zamiany = 0;

        for (int i = 0; i < L.Length - 1; i++)
        { // szukamy najmniejszego elementu w L dla (i, N - 1)
            int k = i;
            for (int j = i + 1; j < L.Length; j++)
            {
                if (L[k] > L[j]) k = j;
                porownania++;
            }
            // zamieniamy z go z elementem i-tym
            zamiany++;
            int t = L[k]; L[k] = L[i]; L[i] = t;

        }
        Console.WriteLine("Porownania: " + porownania + " Zamiany: " + zamiany);
    }
    //    liczba porównań jest stała:
    //W(n) = A(n) = (n − 1) + (n − 2) + . . . + 1 = n(n−1)/2
    //Liczba przestawień ≤ (n − 1)

    static void Wstawianie(int[] L)
    {
        int porownania = 0;
        int zamiany = 0;
        int k, j;
        for (int i = 1; i < L.Length; i++)
        {
            k = L[i];
            j = i;
            while (j > 0 && L[j - 1] > k)
            {
                L[j] = L[j - 1]; // przesuwam elementy
                zamiany++;
                j--;
                porownania++;
            }
            L[j] = k; // wstawiam w odpowiednie miejsce
        }
        Console.WriteLine("Porownania: " + porownania + " Zamiany: " + zamiany);
    }
    //    Liczba porównań – koszt pesymistyczny W(n) = n(n−1)/2
    //Liczba porównań – koszt oczekiwany A(n) = n(n+1)/4
    //Liczba półzamian = Liczba porównań.
    static void Kopiuj(int[] t, int[] d)
    {
        for (int i = 0; i < d.Length; i++) t[i] = d[i];
    }

    static void Wypisz(int[] t)
    {
        for (int i = 0; i < t.Length; i++) Console.Write(t[i] + " ");
        Console.WriteLine();
    }
    static void Main(string[] args)
    {
        int[] tab0 = { 10, 9, 7, 5, 2, 1, 4, 3, 8, 6 };
        int[] tab1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] tab2 = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        int[] tab3 = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        int[] t = new int[10];

        Kopiuj(t, tab0);
        Wybieranie(t);
        Wypisz(t);
        Kopiuj(t, tab0);
        Wstawianie(t);
        Wypisz(t);

        Kopiuj(t, tab1);
        Wybieranie(t);
        Wypisz(t);
        Kopiuj(t, tab1);
        Wstawianie(t);
        Wypisz(t);

        Kopiuj(t, tab2);
        Wybieranie(t);
        Wypisz(t);
        Kopiuj(t, tab2);
        Wstawianie(t);
        Wypisz(t);

        Kopiuj(t, tab3);
        Wybieranie(t);
        Wypisz(t);
        Kopiuj(t, tab3);
        Wstawianie(t);
        Wypisz(t);

        Console.ReadKey();
    }
}

