//Leo Kay
//Better 21
//ICS3U
//Assignment 6b

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Better21LeoK
{
    public partial class frmBetter21LeoK : Form
    {
        //global variables
        int randomCard, dealerValue1, dealerValue2, dealerValue3, userValue1, userValue2, dealerTotal, userTotal, numOfWins;
        List<Image> deckOfCards = new List<Image>();
        List<int> deckOfValues = new List<int>();
        Random randomNumGenerator = new Random();

        // Constructor of the form
        public frmBetter21LeoK()
        {
            InitializeComponent();

            //disable play again
            this.btnPlayAgain.Enabled = false;

            //call procedures
            CreateDeck();
            DisplayCards();

            //hide userCard3
            this.picUserCard3.Hide();

            //display the number of wins
            numOfWins = 0;
            this.lblWins.Text = "Wins: " + numOfWins;
        }

        private void CreateDeck()
        {
            //clear the list
            deckOfCards.Clear();
            deckOfValues.Clear();

            //populate the list with 52 cards, all different
            //Ace's
            deckOfCards.Add(Properties.Resources.AC);
            deckOfCards.Add(Properties.Resources.AD);
            deckOfCards.Add(Properties.Resources.AH);
            deckOfCards.Add(Properties.Resources.AS);
            //2's
            deckOfCards.Add(Properties.Resources._2C);
            deckOfCards.Add(Properties.Resources._2D);
            deckOfCards.Add(Properties.Resources._2H);
            deckOfCards.Add(Properties.Resources._2S);
            //3's
            deckOfCards.Add(Properties.Resources._3C);
            deckOfCards.Add(Properties.Resources._3D);
            deckOfCards.Add(Properties.Resources._3H);
            deckOfCards.Add(Properties.Resources._3S);
            //4's
            deckOfCards.Add(Properties.Resources._4C);
            deckOfCards.Add(Properties.Resources._4D);
            deckOfCards.Add(Properties.Resources._4H);
            deckOfCards.Add(Properties.Resources._4S);
            //5's
            deckOfCards.Add(Properties.Resources._5C);
            deckOfCards.Add(Properties.Resources._5D);
            deckOfCards.Add(Properties.Resources._5H);
            deckOfCards.Add(Properties.Resources._5S);
            //6's
            deckOfCards.Add(Properties.Resources._6C);
            deckOfCards.Add(Properties.Resources._6D);
            deckOfCards.Add(Properties.Resources._6H);
            deckOfCards.Add(Properties.Resources._6S);
            //7's
            deckOfCards.Add(Properties.Resources._7C);
            deckOfCards.Add(Properties.Resources._7D);
            deckOfCards.Add(Properties.Resources._7H);
            deckOfCards.Add(Properties.Resources._7S);
            //8's
            deckOfCards.Add(Properties.Resources._8C);
            deckOfCards.Add(Properties.Resources._8D);
            deckOfCards.Add(Properties.Resources._8H);
            deckOfCards.Add(Properties.Resources._8S);
            //9's
            deckOfCards.Add(Properties.Resources._9C);
            deckOfCards.Add(Properties.Resources._9D);
            deckOfCards.Add(Properties.Resources._9H);
            deckOfCards.Add(Properties.Resources._9S);
            //10's
            deckOfCards.Add(Properties.Resources._10C);
            deckOfCards.Add(Properties.Resources._10D);
            deckOfCards.Add(Properties.Resources._10H);
            deckOfCards.Add(Properties.Resources._10S);
            //J's
            deckOfCards.Add(Properties.Resources.JC);
            deckOfCards.Add(Properties.Resources.JD);
            deckOfCards.Add(Properties.Resources.JH);
            deckOfCards.Add(Properties.Resources.JS);
            //Q's
            deckOfCards.Add(Properties.Resources.QC);
            deckOfCards.Add(Properties.Resources.QD);
            deckOfCards.Add(Properties.Resources.QH);
            deckOfCards.Add(Properties.Resources.QS);
            //K's
            deckOfCards.Add(Properties.Resources.KC);
            deckOfCards.Add(Properties.Resources.KD);
            deckOfCards.Add(Properties.Resources.KH);
            deckOfCards.Add(Properties.Resources.KS);

            //Create the deckOfValues
            //1's
            deckOfValues.Add(1);
            deckOfValues.Add(1);
            deckOfValues.Add(1);
            deckOfValues.Add(1);
            //2's
            deckOfValues.Add(2);
            deckOfValues.Add(2);
            deckOfValues.Add(2);
            deckOfValues.Add(2);
            //3's
            deckOfValues.Add(3);
            deckOfValues.Add(3);
            deckOfValues.Add(3);
            deckOfValues.Add(3);
            //4's
            deckOfValues.Add(4);
            deckOfValues.Add(4);
            deckOfValues.Add(4);
            deckOfValues.Add(4);
            //5's
            deckOfValues.Add(5);
            deckOfValues.Add(5);
            deckOfValues.Add(5);
            deckOfValues.Add(5);
            //6's
            deckOfValues.Add(6);
            deckOfValues.Add(6);
            deckOfValues.Add(6);
            deckOfValues.Add(6);
            //7's
            deckOfValues.Add(7);
            deckOfValues.Add(7);
            deckOfValues.Add(7);
            deckOfValues.Add(7);
            //8's
            deckOfValues.Add(8);
            deckOfValues.Add(8);
            deckOfValues.Add(8);
            deckOfValues.Add(8);
            //9's
            deckOfValues.Add(9);
            deckOfValues.Add(9);
            deckOfValues.Add(9);
            deckOfValues.Add(9);
            //10's
            deckOfValues.Add(10);
            deckOfValues.Add(10);
            deckOfValues.Add(10);
            deckOfValues.Add(10);
            //J's
            deckOfValues.Add(10);
            deckOfValues.Add(10);
            deckOfValues.Add(10);
            deckOfValues.Add(10);
            //Q's
            deckOfValues.Add(10);
            deckOfValues.Add(10);
            deckOfValues.Add(10);
            deckOfValues.Add(10);
            //K's
            deckOfValues.Add(10);
            deckOfValues.Add(10);
            deckOfValues.Add(10);
            deckOfValues.Add(10);
        }

        private int GetCard(ref PictureBox tmpPicBox)
        {
            //check to see if the deck of cards has less than 5 images
            if (deckOfCards.Count() <= 6)
            {
                CreateDeck();
                MessageBox.Show("You've run out of cards, the dealer is shuffling the deck.", "Shuffling Deck");
            }
            else
            {
                //variables
                int tmpValue = -1;

                //generate a random number between 0 and the number of cards in deckOfCards
                randomCard = randomNumGenerator.Next(0, deckOfCards.Count());

                //add a random card to dealerAndUserCards at the index of counter
                tmpPicBox.Image = deckOfCards[randomCard];

                //get the value of the card
                tmpValue = deckOfValues[randomCard];

                //remove the card from deckOfCards at the randomCard index
                deckOfCards.RemoveAt(randomCard);

                //remove the value from deckOfCards at the randomCard index
                deckOfValues.RemoveAt(randomCard);

                //return the Value
                return tmpValue;
            }
           
        }

        private void DisplayCards()
        {
            //display the front of the cards for the dealer
            this.picDealerCard1.Image = Properties.Resources.Front;
            this.picDealerCard2.Image = Properties.Resources.Front;
            this.picDealerCard3.Image = Properties.Resources.Front;

            //display the users cards
            userValue1 = GetCard(ref this.picUserCard1);
            userValue1 = GetCard(ref this.picUserCard1);

            //add userValue1 and userValue2
            userTotal = userValue1 + userValue2;

            //display the user total
            this.lblUserTotal.Text = "Your Total: " + userTotal;

            Console.WriteLine("userValue1 = " + userValue1);
            Console.WriteLine("userValue2 = " + userValue2);
        }

        private void mniExit_Click(object sender, EventArgs e)
        {
            //close the program
            this.Close();
        }

        private void mniNewGame_Click(object sender, EventArgs e)
        {
            //reset variables
            dealerTotal = 0;
            userTotal = 0;
            numOfWins = 0;

            //clear deckOfCards
            deckOfCards.Clear();

            //call procedures
            CreateDeck();
            DisplayCards();
        }

        private void mniClearWins_Click(object sender, EventArgs e)
        {
            //set wins to 0
            numOfWins = 0;
            this.lblWins.Text = "Wins: " + numOfWins;
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            //call DisplayCards
            DisplayCards();

            //enable and disable buttons
            this.btnHit.Enabled = true;
            this.btnStay.Enabled = true;
            this.btnPlayAgain.Enabled = false;
        }

        private void btnStay_Click(object sender, EventArgs e)
        {
            //display the dealers cards
            dealerValue1 = GetCard(ref this.picDealerCard1);
            dealerValue2 = GetCard(ref this.picDealerCard2);
            dealerValue3 = GetCard(ref this.picDealerCard3);

            //get dealerTotal and userTotal
            dealerTotal = dealerValue1 + dealerValue2 + dealerValue3;
            userTotal = userValue1 + userValue2;

            //display dealerTotal and userTotal
            lblUserTotal.Text = "Your Total: " + userTotal;
            lblDealerTotal.Text = "Dealer Total: " + dealerTotal;

            //check to see who wins and loses
            if (userTotal == dealerTotal)
            {
                this.lblResult.Text = "Draw";
            }
            else if (userTotal == 21)
            {
                this.lblResult.Text = "Blackjack! You Win";
                numOfWins++;
            }
            else if (dealerTotal == 21)
            {
                this.lblResult.Text = "Blackjack! Dealer Wins";
            }
            else if (userTotal > 21)
            {
                this.lblResult.Text = "Dealer Wins";
            }
            else if (dealerTotal > 21)
            {
                if (userTotal < 21)
                {
                    this.lblResult.Text = "You Win!";
                    numOfWins++;
                }
                else
                {
                    this.lblResult.Text = "Dealer Wins";
                }
            }
            else if (userTotal > dealerTotal)
            {
                this.lblResult.Text = "You Win";
                numOfWins++;
            }
            else if (userTotal < dealerTotal)
            {
                this.lblResult.Text = "Dealer Wins";
            }

            //enable and disable buttons
            this.btnHit.Enabled = false;
            this.btnStay.Enabled = false;
            this.btnPlayAgain.Enabled = true;
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            //variables
            int userValue3 = 0;

            //show userCard3
            picUserCard3.Show();

            //get userCard3
            userValue3 = GetCard(ref this.picUserCard3);

            //display the dealers cards
            dealerValue1 = GetCard(ref this.picDealerCard1);
            dealerValue2 = GetCard(ref this.picDealerCard2);
            dealerValue3 = GetCard(ref this.picDealerCard3);

            //get dealerTotal and userTotal
            dealerTotal = dealerValue1 + dealerValue2 + dealerValue3;
            userTotal = userValue1 + userValue2 + userValue3;

            //display dealerTotal and userTotal
            lblUserTotal.Text = "Your Total: " + userTotal;
            lblDealerTotal.Text = "Dealer Total: " + dealerTotal;

            //check to see who wins and loses
            if (userTotal == dealerTotal)
            {
                this.lblResult.Text = "Draw";
            }
            else if (userTotal == 21)
            {
                this.lblResult.Text = "Blackjack! You Win";
                numOfWins++;
            }
            else if (dealerTotal == 21)
            {
                this.lblResult.Text = "Blackjack! Dealer Wins";
            }
            else if (userTotal > 21)
            {
                this.lblResult.Text = "Dealer Wins";
            }
            else if (dealerTotal > 21)
            {
                if (userTotal < 21)
                {
                    this.lblResult.Text = "You Win!";
                    numOfWins++;
                }
                else
                {
                    this.lblResult.Text = "Dealer Wins";
                }
            }
            else if (userTotal > dealerTotal)
            {
                this.lblResult.Text = "You Win";
                numOfWins++;
            }
            else if (userTotal < dealerTotal)
            {
                this.lblResult.Text = "Dealer Wins";
            }

            //enable and disable buttons
            this.btnHit.Enabled = false;
            this.btnStay.Enabled = false;
            this.btnPlayAgain.Enabled = true;
        }
    }
}
