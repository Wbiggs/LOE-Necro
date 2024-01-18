using Lords_Of_Evil___Necromancer.Things;
using Lords_Of_Evil___Necromancer.Things.Kingdom;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;

namespace Lords_Of_Evil___Necromancer;

public partial class Map : ContentPage
{
    //R is rows, C is columns
    public int r = 5;
    public int c = 5;
    public LocationInfo[,] allLocations;
    public MenuPopUp menuPopUp;
    public Player player;
    public EndOfTurnHandeler endOfTurnHandeler;



    public Map()
	{        
        player = new Player("Name Holder", this);
        allLocations= new LocationInfo[r,c];
		InitializeComponent();
        expandGrid();
		populateGrid();
        menuPopUp= new MenuPopUp(this);
        endOfTurnHandeler = new EndOfTurnHandeler(this);
    }

    //Creates the grid size
    private void expandGrid()
    {
        for (int x = 0; x<r; x++)
        {
            MapGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        }
        
        for (int y = 0; y<c; y++)
        {
            MapGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
        }
    }

    //Suffles through all the grids and adds things
    public void populateGrid()
    {
        //Array.Clear(allLocations, 0, allLocations.Length);//used to clear grid
        for (int row=0; row<r; row++) 
        {
            for (int col=0; col<c; col++)
            {
                allLocations[row,col] = new LocationInfo(this, row, col);

                //TEMPORARRY WAY TO ADD THINGS RANDOMLY
                Random random = new Random();
                int chance = random.Next(1, 11);
                if (chance == 1) 
                {
                    allLocations[row, col].Things.Add(new KingdomSpearman("Spearman", this,row,col));
                }
            }
        }

        //Bellow will add the player to location 0 0 just for start
        allLocations[0, 0].Things.Add(player);
        player.row = 0;
        player.col= 0;
        updateXY();
        /*for (int x =0; x<r; x++) 
        {
            for (int y = 0; y<c; y++)
            {
                
                LocationInfo li = new LocationInfo(this,x,y);
                locations.Add(li);
                if (x==0 && y==0) //This adds the player to a location at the start of the program
                {
                    li.Things.Add(player);
                    player.li = li;
                }
                else if (y==1 && x==1) 
                {
                    player.li.Things.Remove(player);
                    li.Things.Add(player);
                    player.li = li;
                }
            }
        }*/

    }

    public Microsoft.Maui.Controls.Grid getGrid()
    {
        return MapGrid;
    }

    //updates the XY coordinates onscreen so player can see
    public void updateXY()
    {
        lblRow.Text = "Y: "+player.row.ToString();
        lblCol.Text = "X: "+player.col.ToString();
        lblMoves.Text = "Moves: "+player.move.ToString();
        lblTurn.Text = "Turn: "+player.turn.ToString();
        lblBonesCollected.Text=player.bonesCollected.ToString();
        lblFleshCollected.Text= player.fleshCollected.ToString();
        lblOreCollected.Text = player.oreCollected.ToString();
        lblMagicCollected.Text = player.magicCollected.ToString();
        LVArmy.ItemsSource= null;
        LVArmy.ItemsSource = player.ArmyRising;

    }

    public void moveCharacter(int row,int col) // minus 1 movement and updates grid location GUI
    {
        allLocations[player.row,player.col].Things.Remove(player);  //take away from old list
        allLocations[row,col].Things.Add(player);  //add to new list
        allLocations[player.row,player.col].refresh(); //clear old list
        player.row = row; //setting new location for player reference
        player.col = col;
        allLocations[player.row,player.col].refresh(); //adding to new location
        alterPlayerMoves();
        updateXY();
    }

    //This deals with the player turns and moves
    public void alterPlayerMoves()
    {
        if (player.move > 1)
        {
            player.move = player.move - 1;
        }
        else
        {
            player.move = player.maxMove;
            player.turn = player.turn + 1;
            endOfTurnHandeler.nextTurn();
        }
    }

    private void Button_Clicked_Down(object sender, EventArgs e)
    {
        if(player.row+1<r)
        {
            moveCharacter(player.row+1,player.col);
        }
    }

    private void Button_Clicked_Right(object sender, EventArgs e)
    {
        if (player.col + 1 < c)
        {
            moveCharacter(player.row, player.col+1);
        }
    }

    private void Button_Clicked_Left(object sender, EventArgs e)
    {
        if (player.col- 1 >= 0) 
        {
            moveCharacter(player.row, player.col - 1);
        }
    }

    private void Button_Clicked_Up(object sender, EventArgs e)
    {
        if (player.row - 1 >= 0)
        {
            moveCharacter(player.row-1, player.col);
        }
    }


    private void Button_Clicked_Up_Left(object sender, EventArgs e)
    {
        if (player.row - 1 >= 0 && player.col - 1 >= 0)
        {
            moveCharacter(player.row-1,player.col-1);
        }
    }

    private void Button_Clicked_Up_Right(object sender, EventArgs e)
    {
        if (player.col + 1 < c && player.row - 1 >= 0)
        {
            moveCharacter(player.row-1, player.col+1);
        }
    }

    private void Button_Clicked_Down_Left(object sender, EventArgs e)
    {
        if (player.col- 1 >= 0 && player.row +1<r) 
        {
            moveCharacter(player.row+1, player.col - 1);
        }
    }

    private void Button_Clicked_Down_Right(object sender, EventArgs e)
    {
        if(player.row+1<r && player.col+1 <c) 
        {
            moveCharacter(player.row+1, player.col+1);
        }
    }

    private void Button_Clicked_MainButton(object sender, EventArgs e)
    {
        menuPopUp.row = player.row;
        menuPopUp.col = player.col;
        updateXY();
        menuPopUp.populateScreen();
        MauiPopup.PopupAction.DisplayPopup(menuPopUp);
    }

    private double previousX;
    private double previousY;


    private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {

        if (e.StatusType == GestureStatus.Running)
        {
            if (previousX.Equals(0) && previousY.Equals(0))
            {
                previousX = e.TotalX;
                previousY = e.TotalY;
            }
            else
            {
                var deltaX = previousX - e.TotalX;
                var deltaY = previousY - e.TotalY;

                MapGrid.TranslationX -= deltaX;
                MapGrid.TranslationY -= deltaY;

                previousX = e.TotalX;
                previousY = e.TotalY;
            }
        }
        else if (e.StatusType == GestureStatus.Completed)
        {
            previousX = 0;
            previousY = 0;
        }
    }
}