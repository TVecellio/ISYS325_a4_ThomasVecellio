using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ISYS325_A4_ThomasVecellio;

public partial class MainForm : Form
{
    private const string HANDS_FOLDER = "hands"; 
    private const string IMAGES_FOLDER = "images";
    private const string DEFAULT_EXT = ".txt";
    private Deck deck;
    private Card[] hand = new Card[5];
    private const int NO_CARD = -1;
    private DeckForm deckform;

    public MainForm()
    {
        InitializeComponent();

        deck = new Deck(cardsImageList);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        
        deck = new Deck(cardsImageList);

        deck.Shuffle();
        deckform?.UpdateDeck();
        for (int i = 0; i < hand.Length; i++)
        {
            DealCard(i);
        }
        UpdateHandPics();
    }

    private void DealCard(int pos)
    {
        if (pos < 0 || pos >= hand.Length) //HAND KEEPS BEING NULL IDK WHY
            return;

        Card dealtCard = deck.DealCard();
        if (dealtCard != null && dealtCard.Id != NO_CARD)
            hand[pos] = dealtCard;
        else
            hand[pos] = null;

    }

    private void dealButton_Click(object sender, EventArgs e)
    {
        deck.Shuffle();
        

        // Deal out the cards
        if (!keep1CheckBox.Checked) DealCard(0);
        if (!keep2CheckBox.Checked) DealCard(1);
        if (!keep3CheckBox.Checked) DealCard(2);
        if (!keep4CheckBox.Checked) DealCard(3);
        if (!keep5CheckBox.Checked) DealCard(4);

        UpdateHandPics();
        ResetKeepCheckboxes();
    }

    private void ResetKeepCheckboxes()
    {
        keep1CheckBox.Checked = false;
        keep2CheckBox.Checked = false;
        keep3CheckBox.Checked = false;
        keep4CheckBox.Checked = false;
        keep5CheckBox.Checked = false;
    }

    private void UpdateHandPics() //ITS NOT THIS EITHER IDK WHAT THE PROBLEM IS
    {
        if (hand[0] != null) hand1PictureBox.Image = hand[0].CardImage;
        else hand1PictureBox.Image = null;

        if (hand[1] != null) hand2PictureBox.Image = hand[1].CardImage;
        else hand2PictureBox.Image = null;

        if (hand[2] != null) hand3PictureBox.Image = hand[2].CardImage;
        else hand3PictureBox.Image = null;

        if (hand[3] != null) hand4PictureBox.Image = hand[3].CardImage;
        else hand4PictureBox.Image = null;

        if (hand[4] != null) hand5PictureBox.Image = hand[4].CardImage;
        else hand5PictureBox.Image = null;
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        saveFileDialog.InitialDirectory = HANDS_FOLDER;
        saveFileDialog.AddExtension = true;
        saveFileDialog.DefaultExt = DEFAULT_EXT;
        if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
        {
            return;
        }

        // Save the current hand to the selected file
        if (!deck.SaveHand(saveFileDialog.FileName, hand))
        {
            MessageBox.Show("Failed to save the hand.");
        }
    }

    private void loadButton_Click(object sender, EventArgs e)
    {
        openFileDialog.InitialDirectory = HANDS_FOLDER;
        if (openFileDialog.ShowDialog() == DialogResult.Cancel)
        {
            return;
        }

        // Load the hand from the selected file
        if (!deck.LoadHand(openFileDialog.FileName, hand))
        {
            MessageBox.Show("Failed to load the hand.");
        }
        UpdateHandPics();
    }

    private void hand1PictureBox_Click(object sender, EventArgs e)
    {
        keep1CheckBox.Checked = !keep1CheckBox.Checked;
    }

    private void hand2PictureBox_Click(object sender, EventArgs e)
    {
        keep2CheckBox.Checked = !keep2CheckBox.Checked;
    }

    private void hand3PictureBox_Click(object sender, EventArgs e)
    {
        keep3CheckBox.Checked = !keep3CheckBox.Checked;
    }

    private void hand4PictureBox_Click(object sender, EventArgs e)
    {
        keep4CheckBox.Checked = !keep4CheckBox.Checked;
    }

    private void hand5PictureBox_Click(object sender, EventArgs e)
    {
        keep5CheckBox.Checked = !keep5CheckBox.Checked;
    }

    private void ShowDeckButton_Click(object sender, EventArgs e)
    {
        
        if (deckform == null || !deckform.Visible)
        {

            deckform = new DeckForm(deck);  

            
            deckform.Show();
        }
        else
        { 
            deckform.BringToFront();
        }
    }
}
