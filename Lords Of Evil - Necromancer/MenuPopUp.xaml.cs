using Lords_Of_Evil___Necromancer.Spells;
using MauiPopup;
using MauiPopup.Views;
using Microsoft.VisualBasic;

namespace Lords_Of_Evil___Necromancer;

public partial class MenuPopUp : BasePopupPage
{
	Map Map;
	public int row;
	public int col;
	public MenuPopUp(Map map)
	{
        InitializeComponent();
		this.Map = map;
		row = Map.player.row; 
		col = Map.player.col;
        //LVSpells.SetBinding(ListView.ItemsSourceProperty, nameof(Map.player.spells));

		populateScreen();
        LVSpells.ItemTapped += LVSpells_ItemTapped;

    }

    private void LVSpells_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        
        if (e.Item is SpellDeathSpeed tappedItem) 
        {            
            tappedItem.useSpell();
        }
        else if (e.Item is SpellDanseMacabre skeletonItem) 
        {
            skeletonItem.useSpell();
        }
        else if (e.Item is SpellRaiseZombie zombie)
        {
            zombie.useSpell();
        }
        else if (e.Item is SpellKnitFlesh fleshpile)
        {
            fleshpile.useSpell();
        }
        else if (e.Item is SpellBuildFleshGolem fleshGolem)
        {
            fleshGolem.useSpell();
        }
        else if (e.Item is SpellBonePile bonepile)
        {
            bonepile.useSpell();
        }        
        else if (e.Item is SpellSummonWanderingSpiritcs wandering)
        {
            wandering.useSpell();
        }
        else if (e.Item is SpellSummonHaunt haunt) 
        {
            haunt.useSpell();
        }
        populateScreen();
        Map.updateXY();
    }

    public void populateScreen()
	{
		lblMovesLeft.Text ="Moves: "+Map.player.move.ToString();

        lblpopBonesCollected.Text = Map.player.bonesCollected.ToString();
        lblpopFleshCollected.Text = Map.player.fleshCollected.ToString();
        lblpopOreCollected.Text = Map.player.oreCollected.ToString();
        lblpopMagicCollected.Text = Map.player.magicCollected.ToString();
        

		lblMapBonesCollected.Text= Map.allLocations[row,col].bonesAmount.Text;
		lblMapFleshCollected.Text= Map.allLocations[row,col].fleshAmount.Text;
		lblMapOreCollected.Text= Map.allLocations[row,col].oreAmount.Text;
        LVSpells.ItemsSource = null;
        LVSpells.ItemsSource = Map.player.spells;

    }

    private void btnClose_Clicked(object sender, EventArgs e)
    {
		PopupAction.ClosePopup(this);

    }

    private void btnGraveRob_Clicked(object sender, EventArgs e)
    {
        int z = int.Parse(Map.allLocations[row, col].bonesAmount.Text);

        if (z>0)
		{
			Map.alterPlayerMoves();
            Map.allLocations[row, col].bonesAmount.Text = (z -1).ToString();
            Map.player.bonesCollected++;
            populateScreen();
            Map.updateXY();
		}
    }

    private void btnDisect_Clicked(object sender, EventArgs e)
    {
        int z = int.Parse(Map.allLocations[row, col].fleshAmount.Text);
        if ( z > 0)
        {
            Map.alterPlayerMoves();
            Map.allLocations[row, col].fleshAmount.Text = (z - 1).ToString();
            Map.player.fleshCollected++;
            populateScreen();
            Map.updateXY();
        }
    }

    private void btnMine_Clicked(object sender, EventArgs e)
    {
        int z = int.Parse(Map.allLocations[row, col].oreAmount.Text);
        if (z > 0 && Map.player.move>=2)
        {
            Map.alterPlayerMoves();
            Map.alterPlayerMoves();
            Map.allLocations[row, col].oreAmount.Text = (z - 1).ToString();
            Map.player.oreCollected++;
            populateScreen();
            Map.updateXY();
        }
    }
    private void btnMagic_Clicked(object sender, EventArgs e)
    {
        if (Map.player.move>=3)
        {
            Map.alterPlayerMoves();
            Map.alterPlayerMoves();
            Map.alterPlayerMoves();
            
            Map.player.magicCollected++;
            populateScreen();
            Map.updateXY();
        }
    }
}