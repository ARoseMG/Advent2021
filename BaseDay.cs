using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

public class BaseDay
{
    /// <summary>
    /// An array of lines of text from the input file
    /// </summary>
    public List<string> inputLines;

    /// <summary>
    /// Some puzzles' input resembles a grid.
    /// For those, this is the height.
    /// </summary>
    public int height => inputLines.Count;

    /// <summary>
    /// Some puzzles' input resembles a rectangular grid.
    /// For those, this is the width.
    /// </summary>
    public int width => inputLines[0].Length;

    /// <summary>
    /// The name of each day's puzzle
    /// </summary>
    /// <value></value>
    public virtual string Name { get; }

    /// <summary>
    /// The name of the input file.
    /// By default, matches the class name.
    /// </summary>
    public virtual string InputFileName()
    {
        return this.GetType().Name + ".txt";
    }
    
    /// <summary>
    /// Read the .txt file whose name matches this (derived) class
    /// </summary>
    /// <returns>true if the file was found</returns>
    public bool ReadInput()
    {
        string binDir = Directory.GetCurrentDirectory();
        string filename = binDir + "\\" + InputFileName();
        if (!File.Exists(filename))
        {
            Console.WriteLine($"Input file {filename} not found!");
            return false;
        }
        
        var lines = File.ReadLines(filename);
        inputLines = new List<string>(lines);
        Console.WriteLine($"Read {inputLines.Count} lines from {filename}");
        return true;
    }

    /// <summary>
    /// Upon construction, reads the matching input file.
    /// </summary>
    public BaseDay()
    {
        ReadInput();
    }

    public override string ToString()
    {
        return this.GetType().Name;
    }

    // Does this class override the specified method?
    bool Overrides(string method)
    {
        return GetType().GetMethod("Part1").DeclaringType == GetType();
    }
    
    public bool ImplementsPart1 => Overrides("Part1");
    public bool ImplementsPart2 => Overrides("Part2");

    public virtual object Part1()
    {
        return null;
    }

    public virtual object Part2()
    {
        return null;
    }

    /// <summary>
    /// Discover derived types
    /// </summary>
    /// <returns></returns>
    public static Type[] DiscoverDerivedClasses()
    {
        var baseType = typeof(BaseDay);
        var assembly = Assembly.GetAssembly(baseType);
        return assembly.GetTypes()
            .Where(t => t != baseType && baseType.IsAssignableFrom(t))
            .OrderBy(t => $"{t.Name.Length} {t.Name}")
            .ToArray();
    }

}
