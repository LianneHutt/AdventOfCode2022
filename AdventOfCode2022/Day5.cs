internal class Day5
{
    public static void Part1()
    {
        var reader = new StringReader(Input);
        string? line = reader.ReadLine();

        var towers = new List<IList<char>>();
        var towerCount = (line!.Length + 1) / 4;
        for (var tower = 0; tower < towerCount; tower++)
            towers.Add(new List<char>());

        while (!string.IsNullOrEmpty(line))
        {
            for (var lineIndex = 0; lineIndex < line.Length; lineIndex++)
            {
                if (char.IsLetter(line[lineIndex]))
                {
                    var towerIndex = lineIndex / 4;
                    towers[towerIndex].Add(line[lineIndex]);
                }
            }

            line = reader.ReadLine();
        }

        for (var index = 0; index < towers.Count; index++)
            towers[index] = towers[index].Reverse().ToList();

        if (string.IsNullOrEmpty(line) || line[1] == 1)
            line = reader.ReadLine();

        while (line != null && line.Contains("move"))
        {
            var indexOffset = 0;
            var cratesToMove = ((int)char.GetNumericValue(line[5]));
            if (char.IsDigit(line[6]))
            {
                cratesToMove = (int.Parse(cratesToMove.ToString() + char.GetNumericValue(line[6])));
                indexOffset = 1;
            }

            var from = (int)char.GetNumericValue(line[12 + indexOffset]) - 1;
            var to = (int)char.GetNumericValue(line[17 + indexOffset]) - 1;

            for (var cratesMoved = 0; cratesMoved < cratesToMove; cratesMoved++)
            {
                towers[to].Add(towers[from].Last());
                towers[from].RemoveAt(towers[from].Count - 1);
            }

            line = reader.ReadLine();
        }

        foreach (var tower in towers)
            Console.Write(tower.Last());
    }

    public static void Part2()
    {
        var reader = new StringReader(Input);
        string? line = reader.ReadLine();

        var towers = new List<IList<char>>();
        var towerCount = (line!.Length + 1) / 4;
        for (var tower = 0; tower < towerCount; tower++)
            towers.Add(new List<char>());

        while (!string.IsNullOrEmpty(line))
        {
            for (var lineIndex = 0; lineIndex < line.Length; lineIndex++)
            {
                var towerIndex = lineIndex / 4;
                towers[towerIndex].Add(line[lineIndex]);
            }

            line = reader.ReadLine();
        }


        for (var index = 0; index < towers.Count; index++)
            towers[index] = towers[index].Reverse().ToList();

        if (string.IsNullOrEmpty(line) || line[1] == 1)
            line = reader.ReadLine();

        while (line != null && line.Contains("move"))
        {
            var indexOffset = 0;
            var cratesToMove = ((int)char.GetNumericValue(line[5]));
            if (char.IsDigit(line[6]))
            {
                cratesToMove = (int.Parse(cratesToMove.ToString() + char.GetNumericValue(line[6])));
                indexOffset = 1;
            }

            var from = (int)char.GetNumericValue(line[12 + indexOffset]) - 1;
            var to = (int)char.GetNumericValue(line[17 + indexOffset]) - 1;

            for (var cratesToBeMoved = cratesToMove; cratesToBeMoved > 0; cratesToBeMoved--)
            {
                var tower = towers[from];
                towers[to].Add(tower[^cratesToBeMoved]);
                tower.RemoveAt(tower.Count - cratesToBeMoved);
            }

            line = reader.ReadLine();
        }

        foreach (var tower in towers)
            Console.Write(tower.Last());
    }

    #region Inputs

    private const string TestInput = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";

    private const string Input = @"[N]     [C]                 [Q]    
[W]     [J] [L]             [J] [V]
[F]     [N] [D]     [L]     [S] [W]
[R] [S] [F] [G]     [R]     [V] [Z]
[Z] [G] [Q] [C]     [W] [C] [F] [G]
[S] [Q] [V] [P] [S] [F] [D] [R] [S]
[M] [P] [R] [Z] [P] [D] [N] [N] [M]
[D] [W] [W] [F] [T] [H] [Z] [W] [R]
 1   2   3   4   5   6   7   8   9 

move 1 from 3 to 9
move 3 from 5 to 3
move 4 from 2 to 5
move 4 from 1 to 2
move 3 from 5 to 7
move 3 from 1 to 2
move 4 from 8 to 7
move 4 from 9 to 7
move 4 from 2 to 7
move 2 from 3 to 6
move 3 from 6 to 2
move 5 from 4 to 7
move 7 from 3 to 7
move 5 from 6 to 9
move 2 from 4 to 8
move 1 from 3 to 2
move 4 from 2 to 7
move 2 from 2 to 8
move 8 from 8 to 5
move 1 from 2 to 4
move 1 from 2 to 9
move 7 from 5 to 4
move 31 from 7 to 1
move 9 from 9 to 3
move 12 from 1 to 9
move 15 from 1 to 7
move 4 from 3 to 8
move 2 from 5 to 1
move 12 from 7 to 5
move 2 from 8 to 2
move 12 from 5 to 4
move 1 from 3 to 5
move 6 from 1 to 3
move 1 from 1 to 5
move 1 from 8 to 7
move 1 from 8 to 5
move 7 from 7 to 8
move 5 from 8 to 2
move 11 from 4 to 2
move 10 from 3 to 1
move 1 from 7 to 5
move 10 from 1 to 3
move 5 from 4 to 2
move 1 from 4 to 6
move 7 from 2 to 3
move 9 from 9 to 5
move 15 from 2 to 3
move 1 from 9 to 1
move 7 from 5 to 3
move 1 from 2 to 4
move 2 from 9 to 2
move 1 from 8 to 9
move 5 from 5 to 3
move 1 from 8 to 7
move 1 from 2 to 4
move 1 from 7 to 6
move 1 from 1 to 6
move 1 from 6 to 9
move 1 from 5 to 4
move 1 from 6 to 4
move 1 from 6 to 8
move 2 from 9 to 4
move 12 from 3 to 1
move 8 from 4 to 8
move 1 from 9 to 8
move 10 from 8 to 6
move 1 from 6 to 7
move 6 from 6 to 9
move 1 from 2 to 7
move 1 from 4 to 7
move 2 from 7 to 3
move 1 from 1 to 3
move 6 from 9 to 1
move 2 from 6 to 7
move 12 from 1 to 3
move 5 from 1 to 9
move 1 from 7 to 3
move 38 from 3 to 7
move 19 from 7 to 8
move 19 from 8 to 2
move 1 from 9 to 6
move 5 from 3 to 7
move 2 from 6 to 7
move 1 from 3 to 9
move 2 from 3 to 6
move 4 from 2 to 6
move 6 from 2 to 4
move 14 from 7 to 9
move 8 from 2 to 5
move 19 from 9 to 3
move 6 from 4 to 1
move 6 from 1 to 4
move 4 from 4 to 3
move 10 from 7 to 6
move 1 from 6 to 4
move 22 from 3 to 1
move 5 from 1 to 6
move 5 from 5 to 8
move 1 from 7 to 4
move 1 from 2 to 3
move 15 from 6 to 9
move 3 from 8 to 4
move 2 from 3 to 1
move 6 from 9 to 1
move 1 from 3 to 9
move 1 from 3 to 1
move 1 from 5 to 9
move 1 from 7 to 1
move 1 from 8 to 2
move 6 from 9 to 2
move 2 from 9 to 1
move 3 from 6 to 3
move 2 from 9 to 5
move 1 from 6 to 7
move 2 from 2 to 7
move 3 from 3 to 5
move 1 from 8 to 9
move 7 from 4 to 7
move 1 from 6 to 3
move 2 from 9 to 5
move 10 from 1 to 5
move 19 from 1 to 8
move 9 from 7 to 1
move 1 from 3 to 5
move 2 from 2 to 4
move 2 from 2 to 6
move 2 from 6 to 4
move 7 from 1 to 7
move 3 from 7 to 3
move 2 from 4 to 1
move 3 from 3 to 4
move 1 from 2 to 4
move 2 from 4 to 1
move 2 from 4 to 8
move 20 from 8 to 2
move 1 from 8 to 3
move 4 from 7 to 8
move 14 from 2 to 6
move 3 from 1 to 2
move 2 from 1 to 7
move 1 from 4 to 6
move 1 from 1 to 5
move 4 from 2 to 8
move 3 from 7 to 6
move 1 from 4 to 6
move 2 from 7 to 9
move 1 from 2 to 6
move 1 from 3 to 1
move 3 from 5 to 8
move 1 from 1 to 4
move 2 from 9 to 5
move 4 from 6 to 7
move 1 from 4 to 1
move 1 from 8 to 5
move 1 from 7 to 6
move 1 from 2 to 9
move 2 from 7 to 1
move 1 from 1 to 3
move 1 from 7 to 2
move 4 from 2 to 7
move 1 from 1 to 3
move 2 from 3 to 2
move 9 from 8 to 3
move 1 from 8 to 6
move 2 from 7 to 3
move 1 from 7 to 4
move 1 from 9 to 7
move 1 from 7 to 2
move 2 from 2 to 8
move 6 from 5 to 2
move 5 from 3 to 7
move 1 from 4 to 7
move 3 from 7 to 1
move 11 from 5 to 8
move 2 from 1 to 6
move 2 from 1 to 8
move 2 from 5 to 9
move 1 from 7 to 2
move 2 from 5 to 4
move 17 from 6 to 7
move 1 from 4 to 1
move 1 from 1 to 7
move 1 from 6 to 5
move 1 from 6 to 2
move 9 from 2 to 5
move 1 from 6 to 7
move 9 from 7 to 4
move 3 from 7 to 8
move 3 from 3 to 4
move 8 from 7 to 9
move 11 from 8 to 1
move 1 from 4 to 3
move 1 from 7 to 4
move 9 from 9 to 4
move 5 from 1 to 7
move 8 from 5 to 1
move 3 from 3 to 4
move 6 from 7 to 9
move 3 from 8 to 5
move 1 from 3 to 8
move 1 from 5 to 8
move 2 from 9 to 1
move 3 from 9 to 7
move 2 from 7 to 9
move 3 from 9 to 8
move 1 from 7 to 3
move 1 from 3 to 9
move 7 from 4 to 3
move 18 from 4 to 2
move 8 from 1 to 6
move 1 from 6 to 7
move 2 from 3 to 1
move 14 from 2 to 6
move 5 from 1 to 6
move 5 from 3 to 2
move 2 from 9 to 5
move 3 from 1 to 8
move 1 from 7 to 9
move 3 from 5 to 1
move 4 from 8 to 4
move 1 from 2 to 7
move 6 from 2 to 5
move 2 from 1 to 6
move 14 from 6 to 1
move 2 from 4 to 7
move 2 from 4 to 6
move 12 from 1 to 6
move 8 from 8 to 3
move 11 from 6 to 1
move 1 from 1 to 6
move 15 from 6 to 9
move 3 from 7 to 3
move 11 from 1 to 4
move 3 from 5 to 3
move 10 from 9 to 5
move 2 from 6 to 9
move 2 from 2 to 5
move 6 from 3 to 7
move 7 from 9 to 3
move 2 from 1 to 8
move 1 from 9 to 6
move 12 from 3 to 4
move 13 from 5 to 6
move 2 from 7 to 4
move 3 from 7 to 5
move 2 from 8 to 4
move 15 from 6 to 5
move 22 from 4 to 5
move 2 from 3 to 6
move 1 from 7 to 8
move 2 from 1 to 2
move 13 from 5 to 3
move 1 from 8 to 6
move 1 from 6 to 4
move 1 from 2 to 7
move 7 from 5 to 2
move 4 from 4 to 8
move 1 from 6 to 3
move 3 from 5 to 6
move 2 from 8 to 9
move 4 from 5 to 1
move 1 from 9 to 8
move 4 from 2 to 5
move 1 from 7 to 6
move 4 from 6 to 3
move 1 from 6 to 9
move 1 from 9 to 6
move 4 from 1 to 6
move 1 from 9 to 4
move 4 from 6 to 3
move 1 from 6 to 4
move 14 from 5 to 6
move 23 from 3 to 1
move 2 from 5 to 6
move 1 from 4 to 2
move 6 from 5 to 7
move 16 from 6 to 5
move 2 from 2 to 6
move 2 from 6 to 1
move 2 from 2 to 4
move 1 from 2 to 8
move 15 from 1 to 3
move 4 from 8 to 2
move 9 from 1 to 8
move 12 from 5 to 7
move 2 from 5 to 1
move 1 from 4 to 6
move 1 from 5 to 6
move 3 from 7 to 3
move 2 from 8 to 6
move 1 from 2 to 3
move 2 from 3 to 5
move 3 from 1 to 9
move 12 from 3 to 9
move 4 from 9 to 7
move 2 from 9 to 5
move 4 from 8 to 5
move 8 from 7 to 2
move 6 from 5 to 8
move 2 from 5 to 7
move 12 from 7 to 1
move 2 from 6 to 7
move 11 from 2 to 4
move 1 from 6 to 5
move 1 from 5 to 8
move 10 from 8 to 6
move 7 from 1 to 9
move 3 from 3 to 8
move 2 from 7 to 4
move 1 from 5 to 3
move 9 from 4 to 7
move 16 from 9 to 6
move 2 from 1 to 6
move 1 from 7 to 8
move 2 from 4 to 1
move 1 from 1 to 5
move 1 from 5 to 7
move 2 from 3 to 9
move 5 from 4 to 6
move 1 from 3 to 6
move 1 from 4 to 5
move 1 from 5 to 8
move 16 from 6 to 5
move 2 from 7 to 6
move 21 from 6 to 2
move 3 from 8 to 7
move 1 from 9 to 1
move 7 from 7 to 1
move 14 from 2 to 5
move 1 from 9 to 3
move 1 from 3 to 1
move 1 from 8 to 3
move 2 from 2 to 6
move 15 from 5 to 1
move 20 from 1 to 8
move 1 from 3 to 5
move 4 from 2 to 8
move 2 from 1 to 2
move 2 from 6 to 8
move 3 from 7 to 6
move 2 from 6 to 7
move 1 from 7 to 2
move 6 from 5 to 6
move 3 from 5 to 9
move 2 from 9 to 6
move 1 from 9 to 4
move 2 from 2 to 3
move 1 from 3 to 2
move 2 from 1 to 4
move 1 from 3 to 9
move 2 from 4 to 7
move 4 from 8 to 4
move 8 from 8 to 6
move 5 from 6 to 9
move 6 from 6 to 7
move 6 from 6 to 3
move 5 from 3 to 2
move 2 from 2 to 3
move 10 from 7 to 1
move 2 from 5 to 2
move 2 from 4 to 1
move 5 from 5 to 9
move 2 from 3 to 5
move 2 from 9 to 4
move 5 from 4 to 8
move 8 from 9 to 6
move 16 from 1 to 9
move 7 from 2 to 7
move 10 from 9 to 4
move 10 from 4 to 8
move 1 from 7 to 3
move 1 from 2 to 5
move 3 from 5 to 7
move 2 from 3 to 6
move 5 from 7 to 4
move 4 from 4 to 5
move 17 from 8 to 3
move 9 from 6 to 2
move 17 from 3 to 9
move 9 from 8 to 3
move 2 from 5 to 6
move 1 from 5 to 8
move 5 from 2 to 4
move 1 from 6 to 9
move 3 from 9 to 5
move 3 from 7 to 4
move 13 from 9 to 3
move 3 from 9 to 2
move 1 from 9 to 8
move 2 from 6 to 4
move 9 from 3 to 4
move 3 from 9 to 3
move 1 from 8 to 1
move 2 from 5 to 2
move 5 from 4 to 7
move 1 from 9 to 2
move 6 from 7 to 2
move 1 from 9 to 6
move 9 from 2 to 4
move 1 from 1 to 7
move 1 from 6 to 5
move 1 from 7 to 4
move 4 from 4 to 2
move 12 from 3 to 6
move 7 from 2 to 5
move 1 from 2 to 1
move 1 from 1 to 9
move 2 from 2 to 6
move 5 from 8 to 2
move 8 from 6 to 3
move 1 from 9 to 3
move 4 from 2 to 7
move 1 from 3 to 2
move 2 from 2 to 7
move 1 from 2 to 5
move 3 from 6 to 3
move 10 from 5 to 8
move 1 from 5 to 3
move 1 from 6 to 5
move 5 from 8 to 7
move 1 from 5 to 8
move 2 from 6 to 3
move 5 from 7 to 4
move 3 from 3 to 6
move 2 from 8 to 6
move 3 from 8 to 2
move 1 from 3 to 7
move 15 from 4 to 5
move 10 from 4 to 1
move 7 from 3 to 5
move 1 from 2 to 9
move 5 from 5 to 7
move 8 from 5 to 9
move 4 from 3 to 6
move 3 from 9 to 6
move 3 from 1 to 4
move 10 from 7 to 4
move 2 from 2 to 4
move 2 from 3 to 5
move 1 from 7 to 2
move 1 from 7 to 6
move 6 from 6 to 5
move 7 from 5 to 3
move 1 from 8 to 3
move 5 from 1 to 6
move 9 from 5 to 3
move 14 from 4 to 7
move 1 from 2 to 8
move 1 from 8 to 2
move 1 from 6 to 4
move 2 from 4 to 7
move 1 from 2 to 9
move 1 from 4 to 8
move 2 from 1 to 4
move 8 from 6 to 1
move 1 from 4 to 3
move 1 from 5 to 8
move 12 from 7 to 3
move 1 from 4 to 8
move 7 from 9 to 1
move 3 from 6 to 2
move 3 from 8 to 7
move 1 from 2 to 9
move 4 from 7 to 1
move 6 from 1 to 7
move 2 from 2 to 8
move 7 from 7 to 3
move 10 from 1 to 6
move 20 from 3 to 1
move 2 from 6 to 7
move 1 from 9 to 1
move 8 from 6 to 8
move 6 from 8 to 9
move 5 from 3 to 7
move 2 from 7 to 3
move 2 from 9 to 2
move 5 from 1 to 3
move 2 from 9 to 8
move 8 from 3 to 7
move 6 from 8 to 3
move 1 from 9 to 8
move 19 from 1 to 6
move 17 from 3 to 6
move 2 from 2 to 4
move 1 from 3 to 5
move 1 from 4 to 1
move 1 from 4 to 8
move 2 from 8 to 5
move 1 from 5 to 1
move 1 from 5 to 4
move 1 from 5 to 7
move 2 from 1 to 3
move 15 from 7 to 4
move 1 from 9 to 7
move 2 from 7 to 6
move 21 from 6 to 4
move 17 from 6 to 8
move 2 from 3 to 5
move 29 from 4 to 9
move 15 from 9 to 7
move 1 from 5 to 1
move 9 from 8 to 2
move 10 from 9 to 3
move 8 from 2 to 6";
    #endregion
}