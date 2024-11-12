using System;
using System.Collections.Generic;
using System.Drawing;

public class Deck
{
    private List<Card> cards;
    private ImageList imageList;

    public Deck(ImageList imageList)
    {
        this.imageList = imageList;
        cards = new List<Card>();
        Shuffle(); 
    }

    public int Count => cards.Count;

    public Card GetCard(int index)
    {
        return (index >= 0 && index < cards.Count) ? cards[index] : Card.NoCard;
    }

    public void Shuffle()
    {
        cards.Clear();
        if(imageList.Images.Count == 0)
            {
            // Handle the case where there are no images in the list
            MessageBox.Show("ImageList is empty.");
            return;
        }
        for (int i = 0; i < imageList.Images.Count; i++)
        {
            string imageKey = imageList.Images.Keys[i];
            if (string.IsNullOrEmpty(imageKey))
            {
                MessageBox.Show($"Image key at index {i} is invalid.");
                continue;
            }
            string name = Path.GetFileNameWithoutExtension(imageKey);
            Image cardImage = imageList.Images[imageKey];
            var card = new Card(i, name, cardImage);
            cards.Add(card);
        }

        Random rng = new Random();
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = rng.Next(i + 1);
            (cards[i], cards[j]) = (cards[j], cards[i]);
        }
    }

    public Card DealCard()
    {
        if (cards.Count > 0)
        {
            Card dealtCard = cards[0];
            cards.RemoveAt(0);
            return dealtCard;
        }
        return Card.NoCard;
    }

    public void SwapCards(int index1, int index2)
    {
        if (index1 >= 0 && index1 < cards.Count && index2 >= 0 && index2 < cards.Count)
        {
            var temp = cards[index1];
            cards[index1] = cards[index2];
            cards[index2] = temp;
        }
    }

    public bool SaveHand(string filename, Card[] hand)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Card card in hand)
                {
                    if (card != Card.NoCard)
                    {
                        
                        writer.WriteLine($"{card.Id},{card.Name}");
                    }
                    else
                    {
                        writer.WriteLine("NoCard");
                    }
                }
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    
    public bool LoadHand(string filename, Card[] hand)
    {
        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                for (int i = 0; i < hand.Length; i++)
                {
                    string line = reader.ReadLine();
                    if (line == null) break;

                    if (line == "NoCard")
                    {
                        hand[i] = Card.NoCard;
                    }
                    else
                    {
                        
                        string[] parts = line.Split(',');
                        if (parts.Length >= 2 && int.TryParse(parts[0], out int cardId))
                        {
                            string name = parts[1];
                            if (cardId >= 0 && cardId < imageList.Images.Count)
                            {
                                
                                Image cardImage = imageList.Images[imageList.Images.Keys[cardId]];
                                hand[i] = new Card(cardId, name, cardImage);
                            }
                            else
                            {
                                hand[i] = Card.NoCard;
                            }
                        }
                        else
                        {
                            hand[i] = Card.NoCard;
                        }
                    }
                }
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
}

