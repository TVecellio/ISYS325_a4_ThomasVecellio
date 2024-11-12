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

    public MainForm()
    {
        InitializeComponent();

        deck = new Deck(cardsImageList);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        // Initialize the deck with the image list
        deck = new Deck(cardsImageList);

        deck.Shuffle();
        for (int i = 0; i < hand.Length; i++)
        {
            DealCard(i);
        }
        UpdateHandPics();
    }

    private void DealCard(int pos)
    {
        if (pos < 0 || pos >= hand.Length)
            return;

        Card dealtCard = deck.DealCard();
        hand[pos] = dealtCard.Id != NO_CARD ? dealtCard : null;
    }

    private bool IsRedraw()
    {
        return keep1CheckBox.Checked ||
               keep2CheckBox.Checked ||
               keep3CheckBox.Checked ||
               keep4CheckBox.Checked ||
               keep5CheckBox.Checked;
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

    private void UpdateHandPics()
    {
        hand1PictureBox.Image = hand[0].CardImage;
        hand2PictureBox.Image = hand[1].CardImage;
        hand3PictureBox.Image = hand[2].CardImage;
        hand4PictureBox.Image = hand[3].CardImage;
        hand5PictureBox.Image = hand[4].CardImage;
    }
    private void UpdatePictureBox(PictureBox pictureBox, Card card)
    {
        pictureBox.Image = null;
        if (card != null && card.Id > NO_CARD && card.Id < cardsImageList.Images.Count)
        {
            pictureBox.Image = cardsImageList.Images[card.Id];
        }
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

    private void showDeckButton_Click(object sender, EventArgs e)
    {
        
            DeckForm deckForm = new DeckForm(deck); // Pass the initialized deck
            deckForm.ShowDialog(); // Show as a modal dialog
       

    }
}
