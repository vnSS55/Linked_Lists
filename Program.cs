using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Song_Playlist
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // basically the user control
            int changeMusic;

            // temporary variable for adding a song
            string newSong;

            // variable for Linked lists doubly for the next and last song change
            DoublyLinkedList songs = new DoublyLinkedList();

            // updates the current song
            string currentSong;

            // a pre-made song playlist for default songs for the playlist
            string[] greatPlaylist = new string[] {
                "Bohemian Rhapsody",
                "Billie Jean",
                "Shape of You",
                "Smells Like Teen Spirit",
                "Imagine",
                "Hotel California",
                "Rolling in the Deep",
                "Blinding Lights",
                "Hey Jude",
                "Uptown Funk"
            };

            // add each song
            foreach (string song in greatPlaylist)
            {
                songs.Insert(song);
            }


            while (true)
            {
                // update current song
                currentSong = songs.Current_song();

                //
                Console.WriteLine("Awesome Music App");

                Console.WriteLine($"Now playing: {currentSong}\n");

                Console.WriteLine("< - 1... 2 - >");
                Console.WriteLine("3 - Delete song");
                Console.WriteLine("4 - Add song");
                Console.WriteLine("5 - Exit");
                //

                // Avoid errors that crash the console due to the variable being int
                // if it's not an int it won't crash
                try
                {
                    Console.Write(">");
                    changeMusic = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Enter a value between 1 and 2...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                // better than if for this situation
                switch (changeMusic)
                {
                    // options, self-explanatory
                    case 1:
                        songs.Next_song();
                        break;

                    case 2:
                        songs.Last_song();
                        break;

                    case 3:

                        Console.WriteLine("Are you sure you want to delete the current song? (Y - 1/N - 2)");

                        changeMusic = Convert.ToInt32(Console.ReadLine());

                        if (changeMusic == 1)
                        {
                            songs.Delete(songs.Current_song());
                        }

                        break;

                    case 4:

                        Console.Write("\nWhich song to add?\n>");

                        newSong = Console.ReadLine();

                        songs.Insert(newSong);
                        break;

                    case 5:
                        break;

                    default:
                        Console.WriteLine("Choose between 1 and 2...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
                if (changeMusic == 5) break;

                Console.Clear();
            }
        }
    }
}