using System;
using System.Windows;
using System.Windows.Media;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WpfApp8
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FindGift_Click(object sender, RoutedEventArgs e)
        {


            if (int.TryParse(ageTextBox.Text, out int age)) // Question 1 - odczyt danych od użytkownika. Próba parsowania  adczytanych danych z pola "ageTextBox" do zmiennej "age"  typu "int"
            {
                // sprawdzamy wiek podany przez użytkowika
                if (age > 140) // sprawdzamy podany przez użytkowika wiek czy nie jest większy od 140
                {
                    GiftsImage.Visibility = Visibility.Collapsed;
                    resultTextBlock.Background = new SolidColorBrush(Colors.Yellow);
                    resultTextBlock.Visibility = Visibility.Visible;
                    resultTextBlock.Text = "Invalid age. Person's age cannot be more than 140 years old";
                }

                else
                {
                    string gift1 = FindGift(age);

                    // Question 2
                    #region
                    string gift2 = null; // gift2
                    if (!string.IsNullOrEmpty(music))
                    {
                        gift2 = music;
                    }
                    else if (!string.IsNullOrEmpty(traveling))
                    {
                        gift2 = traveling;
                    }
                    else if (!string.IsNullOrEmpty(sport))
                    {
                        gift2 = sport;
                    }
                    #endregion

                    // Question 3
                    #region
                    string gift3 = null; // gift3
                    if (!string.IsNullOrEmpty(emotions))
                    {
                        gift3 = emotions;
                    }
                    else if (!string.IsNullOrEmpty(things))
                    {
                        gift3 = things;
                    }
                    else if (!string.IsNullOrEmpty(noInfo))
                    {
                        gift3 = noInfo;
                    }
                    #endregion

                    // Question 4
                    #region
                    string gift4 = null; // gift4
                    if (!string.IsNullOrEmpty(mother))
                    {
                        gift4 = mother;
                    }
                    else if (!string.IsNullOrEmpty(father))
                    {
                        gift4 = father;
                    }
                    else if (!string.IsNullOrEmpty(girlfriend))
                    {
                        gift4 = girlfriend;
                    }
                    else if (!string.IsNullOrEmpty(boyfriend))
                    {
                        gift4 = boyfriend;
                    }
                    else if (!string.IsNullOrEmpty(grandparents))
                    {
                        gift4 = grandparents;
                    }
                    else if (!string.IsNullOrEmpty(friends))
                    {
                        gift4 = friends;
                    }
                    #endregion

                    // Question 5
                    #region
                    string gift5 = null; // gift5
                    if (!string.IsNullOrEmpty(birthday))
                    {
                        gift5 = birthday;
                    }
                    else if (!string.IsNullOrEmpty(newYear))
                    {
                        gift5 = newYear;
                    }
                    else if (!string.IsNullOrEmpty(anniversary))
                    {
                        gift5 = anniversary;
                    }
                    else if (!string.IsNullOrEmpty(another))
                    {
                        gift5 = another;
                    }
                    #endregion

                    // Sprawdzamy, czy użytkownik odpowiedział na wszystkie pytania
                    #region

                    if (gift1 is null)
                    {
                        GiftsImage.Visibility = Visibility.Collapsed;
                        resultTextBlock.Background = new SolidColorBrush(Colors.Orange);
                        resultTextBlock.Visibility = Visibility.Visible;
                        resultTextBlock.Text = "Field 1 is empty.\nPlease make sure that you have filled in all the main fields (yellow color)";
                    }
                    else if (gift2 is null)
                    {
                        GiftsImage.Visibility = Visibility.Collapsed;
                        resultTextBlock.Background = new SolidColorBrush(Colors.Orange);
                        resultTextBlock.Visibility = Visibility.Visible;
                        resultTextBlock.Text = "Field 2 is empty.\nPlease make sure that you have filled in all the main fields (yellow color)";
                    }
                    else if (gift3 is null)
                    {
                        GiftsImage.Visibility = Visibility.Collapsed;
                        resultTextBlock.Background = new SolidColorBrush(Colors.Orange);
                        resultTextBlock.Visibility = Visibility.Visible;
                        resultTextBlock.Text = "Field 3 is empty.\nPlease make sure that you have filled in all the main fields (yellow color)";
                    }
                    else if (gift4 is null)
                    {
                        GiftsImage.Visibility = Visibility.Collapsed;
                        resultTextBlock.Background = new SolidColorBrush(Colors.Orange);
                        resultTextBlock.Visibility = Visibility.Visible;
                        resultTextBlock.Text = "Field 4 is empty.\nPlease make sure that you have filled in all the main fields (yellow color)";
                    }
                    else if (gift5 is null)
                    {
                        GiftsImage.Visibility = Visibility.Collapsed;
                        resultTextBlock.Background = new SolidColorBrush(Colors.Orange);
                        resultTextBlock.Visibility = Visibility.Visible;
                        resultTextBlock.Text = "Field 5 is empty.\nPlease make sure that you have filled in all the main fields (yellow color)";
                    }
                    #endregion

                    else
                    {
                        resultTextBlock.Visibility = Visibility.Collapsed;

                        GiftsImage.Visibility = Visibility.Visible;
                        MessageBox.Show($"As a gift, we can recommend you:\n1) {gift1};\n2) {gift2};\n3) {gift3};\n4) {gift4};\n5) {gift5}"); // RESULT
                    }
                }
            }

            else
            {
                GiftsImage.Visibility = Visibility.Collapsed;
                resultTextBlock.Background = new SolidColorBrush(Colors.Red);
                resultTextBlock.Visibility = Visibility.Visible;
                resultTextBlock.Text = "Invalid age. Please enter a valid number.\nMaybe you forgot enter person's age";
            }
        }


        // Question 1
        #region
        private string FindGift(int age)
        {

            if (age <= 5)
            {
                return "Constructor for children";
            }
            else if (age <= 10)
            {
                return "Visiting an amusement park";
            }
            else if (age <= 20)
            {
                return "Book";
            }
            else if (age <= 30)
            {
                return "Phone or Tablet";
            }
            else if (age <= 40)
            {
                return "Voucher to the sea";
            }
            else if (age <= 50)
            {
                return "Perfume";
            }
            else if (age > 50 && age <= 140)
            {
                return "Coffee machine";
            }
            else
            {
                return null;
            }
        }
        #endregion

        // Question 2
        #region 
        private string music;
        private string traveling;
        private string sport;
        private void MusicButton_Checked(object sender, RoutedEventArgs e)
        {
            music = "Headphones";
        }

        private void TravelingButton_Checked(object sender, RoutedEventArgs e)
        {
            traveling = "Travel set";
        }

        private void SportButton_Checked(object sender, RoutedEventArgs e)
        {
            sport = "Sports watch";
        }
        #endregion

        // Question 3
        #region
        private string emotions;
        private string things;
        private string noInfo;
        private void EmotionsButton_Checked(object sender, RoutedEventArgs e)
        {
            emotions = "Hot air balloon flight";
        }

        private void ThingsButton_Checked(object sender, RoutedEventArgs e)
        {
            things = "Coffee machine";
        }

        private void NoInfo_Checked(object sender, RoutedEventArgs e)
        {
            noInfo = "Picture with a commemorative image";
        }
        #endregion

        // Question 4
        #region
        private string mother;
        private string father;
        private string boyfriend;
        private string girlfriend;
        private string grandparents;
        private string friends;

        private void MamButton_Checked(object sender, RoutedEventArgs e)
        {
            mother = "Roomy bag";
        }

        private void FatherButton_Checked(object sender, RoutedEventArgs e)
        {
            father = "Sunglasses";
        }

        private void GirlfriendButton_Checked(object sender, RoutedEventArgs e)
        {
            girlfriend = "Jewelry decoration";
        }

        private void BoyFrindButton_Checked(object sender, RoutedEventArgs e)
        {
            boyfriend = "Leather gloves";
        }

        private void GrandparentsButton_Checked(object sender, RoutedEventArgs e)
        {
            grandparents = "Movie or theater tickets";
        }

        private void FrindsButton_Checked(object sender, RoutedEventArgs e)
        {
            friends = "Cookbook of his favorite cuisine";
        }
        #endregion

        // Question 5
        #region
        private string birthday;
        private string newYear;
        private string anniversary;
        private string another;

        private void BirthdayButton_Checked(object sender, RoutedEventArgs e)
        {
            birthday = "Gift Certificate";
        }

        private void NewYearButton_Checked(object sender, RoutedEventArgs e)
        {
            newYear = "Collection set of sweets.";
        }

        private void AnniversaryButton_Checked(object sender, RoutedEventArgs e)
        {
            anniversary = "Commemorative date pendant";
        }

        private void AnotherButton_Checked(object sender, RoutedEventArgs e)
        {
            another = "Smart backpackSmart backpack";
        }

        #endregion




        // LISTA HOBBY - DATABASE

        #region

        //  HOBBY 1 - Cars, motociles
        #region
        private string hobby1 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Cars and motociles/Cars, motociles..txt"); // odczyt danych z pliku tekstowego

        string[] hobbyTags1 = File.ReadAllLines("C:/Users/user/Desktop/Hobby Database/Cars and motociles/Cars, motocilesTags..txt"); // importujemy zawartość pliku tekstowego do tablicy łańcuchów "hobbyTags1"
        #endregion

        //  HOBBY 2 - Collecting
        #region
        private string hobby2 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Collecting/Collecting.txt"); // odczyt danych z pliku tekstowego
        string[] hobbyTags2 = File.ReadAllLines("C:/Users/user/Desktop/Hobby Database/Collecting/CollectingTags.txt"); // importujemy zawartość pliku tekstowego do tablicy łańcuchów "hobbyTags2"
        #endregion

        //  HOBBY 3 - Computer games
        #region
        private string hobby3 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Computer games/Computer games.txt");
        string[] hobbyTags3 = File.ReadAllLines("C:/Users/user/Desktop/Hobby Database/Computer games/ComputerGamesTags.txt");
        #endregion

        //  HOBBY 4 - Cooking
        #region
        private string hobby4 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Cooking/Cooking.txt");
        string[] hobbyTags4 = File.ReadAllLines("C:/Users/user/Desktop/Hobby Database/Cooking/CookingTags.txt");
        #endregion

        //  HOBBY 5 - Dancing
        #region
        private string hobby5 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Dancing/Dancing.txt");
        string[] hobbyTags5 = File.ReadAllLines("C:/Users/user/Desktop/Hobby Database/Dancing/DancingTags.txt");
        #endregion

        //  HOBBY 6 - Drawing
        #region
        private string hobby6 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Drawing/Drawing.txt");
        string[] hobbyTags6 = File.ReadAllLines("C:/Users/user/Desktop/Hobby Database/Drawing/DrawingTags.txt");
        #endregion

        //  HOBBY 7 - Electronic devices and technology
        #region
        private string hobby7 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Electronic devices and technology/Electronic devices and technology.txt");
        string[] hobbyTags7 = File.ReadAllLines("C:/Users/user/Desktop/Hobby Database/Electronic devices and technology/ElectronicDevicesAndTechnologyTags.txt");
        #endregion

        //  HOBBY 8 - Hunting and fishing
        #region
        private string hobby8 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Hunting and fishing/Hunting and fishing.txt");
        string[] hobbyTags8 = File.ReadAllLines("C:/Users/user/Desktop/Hobby Database/Hunting and fishing/HuntingFishingTags.txt");
        #endregion

        //  HOBBY 9 - Jewelry
        #region
        private string hobby9 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Jewelry/Jewelry.txt");
        string[] hobbyTags9 = File.ReadAllLines("C:/Users/user/Desktop/Hobby Database/Jewelry/JewelryTags.txt");
        #endregion

        //  HOBBY 10 - Learning foreign languages
        #region
        private string hobby10 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Learning foreign languages/Learning foreign languages.txt");
        string[] hobbyTags10 = File.ReadAllLines("C:/Users/user/Desktop/Hobby Database/Learning foreign languages/LearningForeignLanguagesTags.txt");
        #endregion

        //  HOBBY 11 - Martial arts
        #region
        private string hobby11 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Martial arts/Martial arts.txt");
        string[] hobbyTags11 = File.ReadAllLines("C:/Users/user/Desktop/Hobby Database/Martial arts/MartialArtsTags.txt");
        #endregion

        //  HOBBY 12 - Meditation
        #region
        private string hobby12 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Meditation/Meditation.txt");
        string[] hobbyTags12 = File.ReadAllLines("C:/Users/user/Desktop/Hobby Database/Meditation/MeditationTags.txt");
        #endregion

        //  HOBBY 13 - Pets
        #region
        private string hobby13 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Pets/Pets.txt");
        string[] hobbyTags13 = File.ReadAllLines("C:/Users/user/Desktop/Hobby Database/Pets/PetsTags.txt");
        #endregion

        //  HOBBY 14 - Photographing
        #region
        private string hobby14 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Photographing/Photographing.txt");
        string[] hobbyTags14 = File.ReadAllLines("C:/Users/user/Desktop/Hobby Database/Photographing/PhotographingTags.txt");
        #endregion

        //  HOBBY 15 - Reading
        #region
        private string hobby15 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Reading/Reading.txt");
        string[] hobbyTags15 = File.ReadAllLines("C:/Users/user/Desktop/Hobby Database/Reading/ReadingTags.txt");
        #endregion

        //  HOBBY 16 - Riding
        #region
        private string hobby16 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Riding/Riding.txt");
        string[] hobbyTags16 = File.ReadAllLines("C:/Users/user/Desktop/Hobby Database/Riding/RidingTags.txt");
        #endregion

        //  HOBBY 17 - Singing
        #region
        private string hobby17 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Singing/Singing.txt");
        string[] hobbyTags17 = File.ReadAllLines("C:/Users/user/Desktop/Hobby Database/Singing/SingingTags.txt");
        #endregion

        //  HOBBY 18 - Sport
        #region
        private string hobby18 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Sport/Sport.txt");
        string[] hobbyTags18 = File.ReadAllLines("C:/Users/user/Desktop/Hobby Database/Sport/SportTags.txt");
        #endregion

        //  HOBBY 19 - Traveling and Tourism
        #region
        private string hobby19 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Traveling and Tourism/Traveling and Tourism.txt");
        string[] hobbyTags19 = File.ReadAllLines("C:/Users/user/Desktop/Hobby Database/Traveling and Tourism/TravelingAndTourismTags.txt");
        #endregion

        //  HOBBY 20 - Offers of other gifts
        #region
        private string hobby20 = File.ReadAllText(path: "C:/Users/user/Desktop/Hobby Database/Offers of other gifts/Offers of other gifts.txt");
        #endregion

        #endregion


        // WYBÓR PREZENTÓW
        #region
        private void describeButton_Click(object sender, RoutedEventArgs e)
        {
            string interests = DescribtionTextBox.Text.Trim(); // odczyt danych podanych przez użytkownika
            interests = Regex.Replace(interests, @"[\p{P}-[.]]", " "); // musimy zamienić wsystkie znaki interpunkcyjne  na spacje z tekstu, który jest przechowywany w zmiennej "inte+rests " przed zapisem dannych do tablicy "descriptionWords "

            string[] descriptionWords = interests.Split(' ', StringSplitOptions.RemoveEmptyEntries); // zapisywanie danych do tablicy w postaci osobnych wyrazów

            bool hasMatch = false; // zmienna pomocnicza

            foreach (string descriptionWord in descriptionWords)
            {
                // Za pomocą zmiennej pomocniczej "hobbyTag" sprawdzamy dopasowanie wartości zmiennych "hobbyTags", do listy tegów, do listy tegów, która jest przechowywana w zmiennej "descriptionWord" za pomocą wyrażenia lambda i metody Equals()
                // "Any" - sprawdza czy została dopasowana chociaż jedna wartość zmiennej "hobbyTag" do "hobbyTags1/2/3..."


                //  HOBBY 1 - Cars and motociles
                #region 
                if (hobbyTags1.Any(hobbyTag => hobbyTag.Equals(descriptionWord, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(hobby1);
                    hasMatch = true;
                }
                #endregion

                //  HOBBY 2 - Collecting
                #region
                if (hobbyTags2.Any(hobbyTag => hobbyTag.Equals(descriptionWord, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(hobby2);
                    hasMatch = true;
                }
                #endregion

                //  HOBBY 3 - Computer games
                #region
                if (hobbyTags3.Any(hobbyTag => hobbyTag.Equals(descriptionWord, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(hobby3);
                    hasMatch = true;
                }
                #endregion

                //  HOBBY 4 - Cooking
                #region
                if (hobbyTags4.Any(hobbyTag => hobbyTag.Equals(descriptionWord, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(hobby4);
                    hasMatch = true;
                }
                #endregion

                //  HOBBY 5 - Dancing
                #region
                if (hobbyTags5.Any(hobbyTag => hobbyTag.Equals(descriptionWord, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(hobby5);
                    hasMatch = true;
                }
                #endregion

                //  HOBBY 6 - Drawing
                #region
                if (hobbyTags6.Any(hobbyTag => hobbyTag.Equals(descriptionWord, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(hobby6);
                    hasMatch = true;
                }
                #endregion

                //  HOBBY 7 - Electronic devices and technology
                #region
                if (hobbyTags7.Any(hobbyTag => hobbyTag.Equals(descriptionWord, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(hobby7);
                    hasMatch = true;
                    break;
                }
                #endregion

                //  HOBBY 8 - Hunting and fishing
                #region
                if (hobbyTags8.Any(hobbyTag => hobbyTag.Equals(descriptionWord, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(hobby8);
                    hasMatch = true;
                }
                #endregion

                //  HOBBY 9 - Jewelry
                #region
                if (hobbyTags9.Any(hobbyTag => hobbyTag.Equals(descriptionWord, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(hobby9);
                    hasMatch = true;
                }
                #endregion

                //  HOBBY 10 - Learning foreign languages
                #region
                if (hobbyTags10.Any(hobbyTag => hobbyTag.Equals(descriptionWord, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(hobby10);
                    hasMatch = true;
                }
                #endregion

                //  HOBBY 11 - Martial arts
                #region
                if (hobbyTags11.Any(hobbyTag => hobbyTag.Equals(descriptionWord, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(hobby11);
                    hasMatch = true;
                }
                #endregion

                //  HOBBY 12 - Meditation
                #region
                if (hobbyTags12.Any(hobbyTag => hobbyTag.Equals(descriptionWord, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(hobby12);
                    hasMatch = true;
                }
                #endregion

                //  HOBBY 13 - Pets
                #region
                if (hobbyTags13.Any(hobbyTag => hobbyTag.Equals(descriptionWord, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(hobby13);
                }
                #endregion

                //  HOBBY 14 - Photographing
                #region
                if (hobbyTags14.Any(hobbyTag => hobbyTag.Equals(descriptionWord, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(hobby14);
                    hasMatch = true;
                }
                #endregion

                //  HOBBY 15 - Reading
                #region
                if (hobbyTags15.Any(hobbyTag => hobbyTag.Equals(descriptionWord, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(hobby15);
                    hasMatch = true;
                }
                #endregion

                //  HOBBY 16 - Riding
                #region
                if (hobbyTags16.Any(hobbyTag => hobbyTag.Equals(descriptionWord, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(hobby16);
                    hasMatch = true;
                }
                #endregion

                //  HOBBY 17 - Singing
                #region
                if (hobbyTags17.Any(hobbyTag => hobbyTag.Equals(descriptionWord, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(hobby17);
                    hasMatch = true;
                }
                #endregion

                //  HOBBY 18 - Sport
                #region
                if (hobbyTags18.Any(hobbyTag => hobbyTag.Equals(descriptionWord, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(hobby18);
                    hasMatch = true;
                }
                #endregion

                //  HOBBY 19 - Traveling and Tourism
                #region
                if (hobbyTags19.Any(hobbyTag => hobbyTag.Equals(descriptionWord, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show(hobby19);
                    hasMatch = true;
                }
                #endregion

            }
            //  HOBBY 20 - Offers of other gifts
            #region
            if (!hasMatch)
            {
                MessageBox.Show(hobby20);
            }
            #endregion
        }
        #endregion

    }
}




