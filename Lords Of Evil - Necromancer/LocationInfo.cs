using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lords_Of_Evil___Necromancer.Things;
using Microsoft.Maui.Controls;

namespace Lords_Of_Evil___Necromancer
{
    public class LocationInfo
    {
        public List<Thing> Things;
        public StackLayout stackLayout;
        public Entry bonesAmount;
        public Entry fleshAmount;
        public Entry oreAmount;
        Map map;
        Grid mapGrid;
        public ListView listBox;

        public int row;
        public int column;

        public LocationInfo(Map map, int row, int column) 
        {
            this.row = row;
            this.column = column;
            this.map = map;
            mapGrid = map.getGrid();

            Things = new List<Thing>();
            stackLayout= new StackLayout();
            bonesAmount = new Entry { Text = "3" };
            fleshAmount = new Entry { Text = "1" };
            oreAmount = new Entry { Text = "2" };
            populateOnScreen();
            
        }

        private void populateOnScreen()
        {
            ////creating background maptile
            ///
            Frame frame= new Frame
            {
                BackgroundColor = Colors.DarkGreen,
                Padding=new Thickness(5),
                CornerRadius=5,
            };

            ////adding it into the map
            ///
            mapGrid.SetRow(frame, row);
            mapGrid.SetColumn(frame, column);
            mapGrid.Children.Add(frame);

            ////adding content to frame
            ///
            frame.Content = stackLayout;

            ////adding resources top info
            ///
            StackLayout stacking = new StackLayout { Orientation = StackOrientation.Horizontal };
            stackLayout.Children.Add(stacking);

            ////adding resource info bar and images
            ///
            Image bonesImage = new Image 
            {
                Source = new FileImageSource { File = "Images/BonePile.png" },
                HeightRequest =30,
                WidthRequest=30,
            };
            stacking.Children.Add(bonesImage);
            stacking.Children.Add(bonesAmount);
            
            Image FleshImage = new Image { Source = new FileImageSource { File = "Images/UnderConstruction.png" },
                HeightRequest = 30,
                WidthRequest = 30,
            };
            stacking.Children.Add(FleshImage);
            stacking.Children.Add(fleshAmount);
            
            Image OreImage = new Image { Source = new FileImageSource { File = "Images/Ore.png" },
                HeightRequest = 30,
                WidthRequest = 30,
            };
            stacking.Children.Add(OreImage);
            stacking.Children.Add(oreAmount);

            ////adding more to things to tile
            ///
            /*Entry entry= new Entry { Text= "row: "+row+", Col: "+column };
            stackLayout.Children.Add(entry);*/
            //Things.Add(new Thing("Grade A",map));
            //Things.Add(new Thing("Long John",map));
            //Things.Add(new Thing("Silver Mine"));
            //Things.Add(new Thing("Has Bro"));
            //Things.Add(new Thing("Locomotion"));

            var lineHeight = Device.GetNamedSize(NamedSize.Medium, typeof(Label))*1.2;
            var desiredHeight = lineHeight * 4; //This # is the amount of lines to be shown on the ListView

            listBox = new ListView
            {
                ItemsSource = Things,
                HeightRequest = desiredHeight,
                ItemTemplate = new DataTemplate(() =>
                {
                    Label lbl = new Label();
                    lbl.SetBinding(Label.TextProperty, "name");
                    return new ViewCell { View = lbl };
                    /*Button lbl = new Button();
                    lbl.SetBinding(Button.TextProperty, "name");
                    return new ViewCell { View = lbl };*/
                })
                
            };
            listBox.ItemTapped += ListBox_ItemTapped;
            stackLayout.Children.Add(listBox);
        }

        private void ListBox_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Player player)
            {
                player.usesThing();
            }
            else if (e.Item is BonePile bonePile) 
            {
                bonePile.usesThing();
            }
            map.updateXY();
        }
        public void refresh()
        {
            listBox.ItemsSource = null;
            listBox.ItemsSource= Things;
        }

        public void addThing(Thing thing)
        {
            Things.Add(thing);
            refresh();
        }

        public Thing getThing(int x)
        {
            return getThing(x);

        }

        public void removeThing(int x) 
        {
            Things.RemoveAt(x);
            refresh();
        }
    }
}
