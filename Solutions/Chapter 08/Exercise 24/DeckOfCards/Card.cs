// Solution to exercises from "C# How to Program 6th edition".
// Chapter 8.
// Exercise 24 (08.29) Card Shuffling and Dealing

class Card
{
    #region Public properties

    // I've change properties to "publice" to be able to compare card's faces and suits. Notice that setters are still private.
    // Card’s face ("Ace", "Deuce", ...).
    public string Face { get; private set; }
    // Card’s suit ("Hearts", "Diamonds", ...).
    public string Suit { get; private set; }

    #endregion

    #region Constructors

    // Two-parameter constructor initializes card's Face and Suit.
    public Card(string face, string suit)
    {
        // Initialize face of card.
        Face = face;
        // Initialize suit of card.
        Suit = suit;
    }

    #endregion

    #region Base overrides

    // Return string representation of Card.
    public override string ToString() => $"{Face} of {Suit}";

    #endregion
}