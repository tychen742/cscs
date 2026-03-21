using System;
using System.IO;
using System.Collections.Generic;

namespace IntroCS
{
   public class FileUtil
   {  // start ReadParagraph chunk
      /// Return a string consisting of a sequence of nonempty lines read
      /// from reader. All the newlines at the ends of these lines are included.
      /// The function ends after reading (but not including) an empty line.
      public static string ReadParagraph(StreamReader reader)
      {  // end heading chunk

         // REPLACE the next line with your lines of code
         // return "You have not coded ReadParagraph yet!\n";

         ////////// this should read each paragraph from the file ////////// 
         string line = "";
         string lines = "";
         do
         {
            line = reader.ReadLine();
            lines = lines + line + "\n";

         } while ((line.Trim() != ""));         ////// works; detecting empty line
         // } while ((line != null));           ////// will drop the whole file

         ///// cannot do this. MUST have return /////
         // if (reader.EndOfStream == true)
         // {
         //    return lines;
         // }
         /////
         
         return lines;                          ///// returns one paragraph

         // string result = "";
         // for (int i =0; i < lst.Count; i++){
         //    result = result + lst[i];
         // }
         // return result;
      }

      //                                start GetParagraphs chunk
      /// Read the remaining empty-line terminated paragraphs
      /// from reader into a new list of paragraph strings,
      /// and return the list.
      /// The function reads all the way to the end of
      /// the file attached to reader.
      /// The file must end with two newlines in sequence: one at the
      /// end of the last nonempty line followed by one for the empty line.
      public static List<string> GetParagraphs(StreamReader reader)
      {
         List<string> all = new List<string>();

         // REPLACE the next line with your lines of code to fill all
         // all.Add("You have not coded GetParagraphs yet!\n");

         while (!reader.EndOfStream)               ///// works; there's got to be other ways
         // do 
         // while (reader.ReadLine() != null)      ///// DON'T READ!!!
         {
            // all.Add(reader.ReadLine());         ///// don't do this
            
            ///// this works; it uses reader.ReadLine() to CONTINUE reading PARAGRAPHS
            all.Add(ReadParagraph(reader));        ///// add directly
            
            ///// this works, too                  ///// add separately
            // string paragraph = ReadParagraph(reader);
            // if (paragraph.Length != 0)
            // {
            //    all.Add(paragraph);
            // }
         }
         // } while (reader.ReadLine() != "" ); 

         ///// just testing
         // for(int i = 0; i < all.Length; i++){   ///// List does not have .Length
         for(int i = 0; i < all.Count(); i++){                 
            Console.WriteLine("{0}.{1}", i, all[i] );
         }

         return all;
      }

      //                                 start GetDictionary chunk
      /// Return a new Dictionary, taking data for it from reader.
      /// Reader contains key-value pairs, where each single-line key is
      /// followed by a possibly multi-line paragraph value that is terminated
      /// by an empty line. The file must end with two newlines in sequence:
      /// one at the end of the last nonempty line followed by one for the
      /// empty line.
      public static Dictionary<string, string> GetDictionary(StreamReader reader)
      {
         Dictionary<string, string> d = new Dictionary<string, string>();

         // add your lines of code to fill d here!


         string key = "";
         string value = "";

         do
         {
            key = reader.ReadLine();

            ////////// not needed; ReadParagraph() takes care of it
            // if (key.Length == 0)
            // {      ///// if line is blank, start over
            // continue;               ///// do not assign anything
            // break;               ///// should not work but it does.//////////
            // }

            // value = "TTTTT" + ReadParagraph(reader);  ///// testing
            value = ReadParagraph(reader);   ///// stops at empty line

            d.Add(key, value);   ///// works
            // d[key] = value;   ///// same as above

         } while (!reader.EndOfStream);

         ////////// test the dictionary //////////
         // foreach (var kvp in d){
         //    Console.WriteLine("key: {0} \nvalue: {1}", kvp.Key, kvp.Value);
         // }

         return d;
      }
      //                                 end GetDictionary chunk

      //Altered Extra credit documentation for GetDictionary:
      /// Return a new Dictionary, taking data for it from reader.
      /// Reader generates key-value pairs, where one or more space
      /// separated keys on a line are followed by a possibly multi-line
      /// paragraph value that is terminated by an empty line.  Each
      /// key on the line is mapped to the same paragraph that follows.
      /// The file must end with two newlines in sequence:  one at the end
      /// of the last nonempty line followed by one for the empty line.
   }
}

