using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reverse
{
  public class CharReverse
  {
    /// <summary>
    /// Reverses the characters in each word in the sentence, while keeping the same order of words.
    /// The words are delimited by: space, comma, dot
    /// eg: The quick brown fox ==> ehT kciuq nworb xof
    /// </summary>
    /// <param name="input">String to reverse words in.</param>
    /// <returns>The string containing reversed words.</returns>
    public string Reverse(string input)
    {
      var reversed = string.Join(" ",
          input.Split(new char[]{' ',',','.'})
         .Select(x => new String(x.Reverse().ToArray()))
         .ToArray());
        
      return reversed;
    }
  }
}