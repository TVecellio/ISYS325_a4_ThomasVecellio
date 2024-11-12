using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISYS325_A4_ThomasVecellio
{
public partial class DeckForm : Form
    {
        private Deck deck;

        public DeckForm(Deck deck)
        {
            InitializeComponent();
            this.deck = deck;
            UpdateDeck();
        }

        public void UpdateDeck()
        {
            cardListBox.Items.Clear();
            for (int i = 0; i < deck.Count; i++)
            {
                cardListBox.Items.Add(deck.GetCard(i));
            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = cardListBox.SelectedIndex;
            if (selectedIndex > 0) // Ensure it’s not the first item
            {
                int newIndex = selectedIndex - 1;
                deck.SwapCards(selectedIndex, newIndex);
                UpdateDeck();

                // Set the new selection to the moved item
                cardListBox.SelectedIndex = newIndex;
            }
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = cardListBox.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < cardListBox.Items.Count - 1) // Ensure it’s not the last item
            {
                int newIndex = selectedIndex + 1;
                deck.SwapCards(selectedIndex, newIndex);
                UpdateDeck();

                // Set the new selection to the moved item
                cardListBox.SelectedIndex = newIndex;
            }
        }


        private void cardListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cardListBox.SelectedItem is Card selectedCard)
            {
                cardPictureBox.Image = selectedCard.CardImage;
            }
        }
    }

}
