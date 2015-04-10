using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Deck
    {
        private int _nombreCartesRestantes;
        private Dictionary<int, Carte> _deck_pioche;
        private Dictionary<int, Carte> _deck_base;
        private int _increment_piocheCarte = 1;

        private int _attaqueCapitaine = 50;
        private int _attaqueAmiral = 100;

        public Deck()
        {
            _deck_pioche = new Dictionary<int, Carte>();
            _deck_base = new Dictionary<int, Carte>();
            CarteAmiral amiral = new CarteAmiral(1, "carte_amiral", _attaqueAmiral, Properties.Resources.carte_amiral, Properties.Resources.carte_amiral_min);

            CarteMarchand marchand2_1 = new CarteMarchand(2, "carte_marchand_2", 2, Properties.Resources.carte_marchand_2, Properties.Resources.carte_marchand_2_min);
            CarteMarchand marchand2_2 = new CarteMarchand(3, "carte_marchand_2", 2, Properties.Resources.carte_marchand_2, Properties.Resources.carte_marchand_2_min);
            CarteMarchand marchand2_3 = new CarteMarchand(4, "carte_marchand_2", 2, Properties.Resources.carte_marchand_2, Properties.Resources.carte_marchand_2_min);
            CarteMarchand marchand2_4 = new CarteMarchand(5, "carte_marchand_2", 2, Properties.Resources.carte_marchand_2, Properties.Resources.carte_marchand_2_min);
            CarteMarchand marchand2_5 = new CarteMarchand(6, "carte_marchand_2", 2, Properties.Resources.carte_marchand_2, Properties.Resources.carte_marchand_2_min);

            CarteMarchand marchand3_1 = new CarteMarchand(7, "carte_marchand_3", 3, Properties.Resources.carte_marchand_3, Properties.Resources.carte_marchand_3_min);
            CarteMarchand marchand3_2 = new CarteMarchand(8, "carte_marchand_3", 3, Properties.Resources.carte_marchand_3, Properties.Resources.carte_marchand_3_min);
            CarteMarchand marchand3_3 = new CarteMarchand(9, "carte_marchand_3", 3, Properties.Resources.carte_marchand_3, Properties.Resources.carte_marchand_3_min);
            CarteMarchand marchand3_4 = new CarteMarchand(10, "carte_marchand_3", 3, Properties.Resources.carte_marchand_3, Properties.Resources.carte_marchand_3_min);
            CarteMarchand marchand3_5 = new CarteMarchand(11, "carte_marchand_3", 3, Properties.Resources.carte_marchand_3, Properties.Resources.carte_marchand_3_min);
            CarteMarchand marchand3_6 = new CarteMarchand(12, "carte_marchand_3", 3, Properties.Resources.carte_marchand_3, Properties.Resources.carte_marchand_3_min);

            CarteMarchand marchand4_1 = new CarteMarchand(13, "carte_marchand_4", 4, Properties.Resources.carte_marchand_4, Properties.Resources.carte_marchand_4_min);
            CarteMarchand marchand4_2 = new CarteMarchand(14, "carte_marchand_4", 4, Properties.Resources.carte_marchand_4, Properties.Resources.carte_marchand_4_min);
            CarteMarchand marchand4_3 = new CarteMarchand(15, "carte_marchand_4", 4, Properties.Resources.carte_marchand_4, Properties.Resources.carte_marchand_4_min);
            CarteMarchand marchand4_4 = new CarteMarchand(16, "carte_marchand_4", 4, Properties.Resources.carte_marchand_4, Properties.Resources.carte_marchand_4_min);
            CarteMarchand marchand4_5 = new CarteMarchand(17, "carte_marchand_4", 4, Properties.Resources.carte_marchand_4, Properties.Resources.carte_marchand_4_min);

            CarteMarchand marchand5_1 = new CarteMarchand(18, "carte_marchand_5", 5, Properties.Resources.carte_marchand_5, Properties.Resources.carte_marchand_5_min);
            CarteMarchand marchand5_2 = new CarteMarchand(19, "carte_marchand_5", 5, Properties.Resources.carte_marchand_5, Properties.Resources.carte_marchand_5_min);
            CarteMarchand marchand5_3 = new CarteMarchand(20, "carte_marchand_5", 5, Properties.Resources.carte_marchand_5, Properties.Resources.carte_marchand_5_min);
            CarteMarchand marchand5_4 = new CarteMarchand(21, "carte_marchand_5", 5, Properties.Resources.carte_marchand_5, Properties.Resources.carte_marchand_5_min);
            CarteMarchand marchand5_5 = new CarteMarchand(22, "carte_marchand_5", 5, Properties.Resources.carte_marchand_5, Properties.Resources.carte_marchand_5_min);


            CarteMarchand marchand6_1 = new CarteMarchand(23, "carte_marchand_6", 6, Properties.Resources.carte_marchand_6, Properties.Resources.carte_marchand_6_min);
            CarteMarchand marchand6_2 = new CarteMarchand(24, "carte_marchand_6", 6, Properties.Resources.carte_marchand_6, Properties.Resources.carte_marchand_6_min);

            CarteMarchand marchand7_1 = new CarteMarchand(25, "carte_marchand_7", 7, Properties.Resources.carte_marchand_7, Properties.Resources.carte_marchand_7_min);
            CarteMarchand marchand8_1 = new CarteMarchand(26, "carte_marchand_8", 8, Properties.Resources.carte_marchand_8, Properties.Resources.carte_marchand_8_min);

            CarteCapitaine capitaineBleu = new CarteCapitaine(27, "carte_capitaine_bleu", "bleu", _attaqueCapitaine, Properties.Resources.carte_capitaine_bleu, Properties.Resources.carte_capitaine_bleu_min);
            CarteCapitaine capitaineRouge = new CarteCapitaine(28, "carte_capitaine_rouge", "rouge", _attaqueCapitaine, Properties.Resources.carte_capitaine_rouge, Properties.Resources.carte_capitaine_rouge_min);
            CarteCapitaine capitaineJaune = new CarteCapitaine(29, "carte_capitaine_jaune", "jaune", _attaqueCapitaine, Properties.Resources.carte_capitaine_jaune, Properties.Resources.carte_capitaine_jaune_min);
            CarteCapitaine capitaineVert = new CarteCapitaine(30, "carte_capitaine_vert", "vert", _attaqueCapitaine, Properties.Resources.carte_capitaine_vert, Properties.Resources.carte_capitaine_vert_min);

            CartePirate pirateBleu1_1 = new CartePirate(31, "carte_pirate_1_bleu", "bleu", 1, Properties.Resources.carte_pirate_1_bleu, Properties.Resources.carte_pirate_1_bleu_min);
            CartePirate pirateBleu1_2 = new CartePirate(32, "carte_pirate_1_bleu", "bleu", 1, Properties.Resources.carte_pirate_1_bleu, Properties.Resources.carte_pirate_1_bleu_min);

            CartePirate pirateVert1_1 = new CartePirate(33, "carte_pirate_1_vert", "vert", 1, Properties.Resources.carte_pirate_1_vert, Properties.Resources.carte_pirate_1_vert_min);
            CartePirate pirateVert1_2 = new CartePirate(34, "carte_pirate_1_vert", "vert", 1, Properties.Resources.carte_pirate_1_vert, Properties.Resources.carte_pirate_1_vert_min);

            CartePirate pirateRouge1_1 = new CartePirate(35, "carte_pirate_1_rouge", "rouge", 1, Properties.Resources.carte_pirate_1_rouge, Properties.Resources.carte_pirate_1_rouge_min);
            CartePirate pirateRouge1_2 = new CartePirate(36, "carte_pirate_1_rouge", "rouge", 1, Properties.Resources.carte_pirate_1_rouge, Properties.Resources.carte_pirate_1_rouge_min);

            CartePirate pirateJaune1_1 = new CartePirate(37, "carte_pirate_1_jaune", "jaune", 1, Properties.Resources.carte_pirate_1_jaune, Properties.Resources.carte_pirate_1_jaune_min);
            CartePirate pirateJaune1_2 = new CartePirate(38, "carte_pirate_1_jaune", "jaune", 1, Properties.Resources.carte_pirate_1_jaune, Properties.Resources.carte_pirate_1_jaune_min);


            CartePirate pirateBleu2_1 = new CartePirate(39, "carte_pirate_2_bleu", "bleu", 2, Properties.Resources.carte_pirate_2_bleu, Properties.Resources.carte_pirate_2_bleu_min);
            CartePirate pirateBleu2_2 = new CartePirate(40, "carte_pirate_2_bleu", "bleu", 2, Properties.Resources.carte_pirate_2_bleu, Properties.Resources.carte_pirate_2_bleu_min);
            CartePirate pirateBleu2_3 = new CartePirate(41, "carte_pirate_2_bleu", "bleu", 2, Properties.Resources.carte_pirate_2_bleu, Properties.Resources.carte_pirate_2_bleu_min);
            CartePirate pirateBleu2_4 = new CartePirate(42, "carte_pirate_2_bleu", "bleu", 2, Properties.Resources.carte_pirate_2_bleu, Properties.Resources.carte_pirate_2_bleu_min);

            CartePirate pirateVert2_1 = new CartePirate(43, "carte_pirate_2_vert", "vert", 2, Properties.Resources.carte_pirate_2_vert, Properties.Resources.carte_pirate_2_vert_min);
            CartePirate pirateVert2_2 = new CartePirate(44, "carte_pirate_2_vert", "vert", 2, Properties.Resources.carte_pirate_2_vert, Properties.Resources.carte_pirate_2_vert_min);
            CartePirate pirateVert2_3 = new CartePirate(45, "carte_pirate_2_vert", "vert", 2, Properties.Resources.carte_pirate_2_vert, Properties.Resources.carte_pirate_2_vert_min);
            CartePirate pirateVert2_4 = new CartePirate(46, "carte_pirate_2_vert", "vert", 2, Properties.Resources.carte_pirate_2_vert, Properties.Resources.carte_pirate_2_vert_min);

            CartePirate pirateRouge2_1 = new CartePirate(47, "carte_pirate_2_rouge", "rouge", 2, Properties.Resources.carte_pirate_2_rouge, Properties.Resources.carte_pirate_2_rouge_min);
            CartePirate pirateRouge2_2 = new CartePirate(48, "carte_pirate_2_rouge", "rouge", 2, Properties.Resources.carte_pirate_2_rouge, Properties.Resources.carte_pirate_2_rouge_min);
            CartePirate pirateRouge2_3 = new CartePirate(49, "carte_pirate_2_rouge", "rouge", 2, Properties.Resources.carte_pirate_2_rouge, Properties.Resources.carte_pirate_2_rouge_min);
            CartePirate pirateRouge2_4 = new CartePirate(50, "carte_pirate_2_rouge", "rouge", 2, Properties.Resources.carte_pirate_2_rouge, Properties.Resources.carte_pirate_2_rouge_min);

            CartePirate pirateJaune2_1 = new CartePirate(51, "carte_pirate_2_jaune", "jaune", 2, Properties.Resources.carte_pirate_2_jaune, Properties.Resources.carte_pirate_2_jaune_min);
            CartePirate pirateJaune2_2 = new CartePirate(52, "carte_pirate_2_jaune", "jaune", 2, Properties.Resources.carte_pirate_2_jaune, Properties.Resources.carte_pirate_2_jaune_min);
            CartePirate pirateJaune2_3 = new CartePirate(53, "carte_pirate_2_jaune", "jaune", 2, Properties.Resources.carte_pirate_2_jaune, Properties.Resources.carte_pirate_2_jaune_min);
            CartePirate pirateJaune2_4 = new CartePirate(54, "carte_pirate_2_jaune", "jaune", 2, Properties.Resources.carte_pirate_2_jaune, Properties.Resources.carte_pirate_2_jaune_min);



            CartePirate pirateBleu3_1 = new CartePirate(55, "carte_pirate_3_bleu", "bleu", 3, Properties.Resources.carte_pirate_3_bleu, Properties.Resources.carte_pirate_3_bleu_min);
            CartePirate pirateBleu3_2 = new CartePirate(56, "carte_pirate_3_bleu", "bleu", 3, Properties.Resources.carte_pirate_3_bleu, Properties.Resources.carte_pirate_3_bleu_min);
            CartePirate pirateBleu3_3 = new CartePirate(57, "carte_pirate_3_bleu", "bleu", 3, Properties.Resources.carte_pirate_3_bleu, Properties.Resources.carte_pirate_3_bleu_min);
            CartePirate pirateBleu3_4 = new CartePirate(58, "carte_pirate_3_bleu", "bleu", 3, Properties.Resources.carte_pirate_3_bleu, Properties.Resources.carte_pirate_3_bleu_min);

            CartePirate pirateVert3_1 = new CartePirate(59, "carte_pirate_3_vert", "vert", 3, Properties.Resources.carte_pirate_3_vert, Properties.Resources.carte_pirate_3_vert_min);
            CartePirate pirateVert3_2 = new CartePirate(60, "carte_pirate_3_vert", "vert", 3, Properties.Resources.carte_pirate_3_vert, Properties.Resources.carte_pirate_3_vert_min);
            CartePirate pirateVert3_3 = new CartePirate(61, "carte_pirate_3_vert", "vert", 3, Properties.Resources.carte_pirate_3_vert, Properties.Resources.carte_pirate_3_vert_min);
            CartePirate pirateVert3_4 = new CartePirate(62, "carte_pirate_3_vert", "vert", 3, Properties.Resources.carte_pirate_3_vert, Properties.Resources.carte_pirate_3_vert_min);

            CartePirate pirateRouge3_1 = new CartePirate(63, "carte_pirate_3_rouge", "rouge", 3, Properties.Resources.carte_pirate_3_rouge, Properties.Resources.carte_pirate_3_rouge_min);
            CartePirate pirateRouge3_2 = new CartePirate(64, "carte_pirate_3_rouge", "rouge", 3, Properties.Resources.carte_pirate_3_rouge, Properties.Resources.carte_pirate_3_rouge_min);
            CartePirate pirateRouge3_3 = new CartePirate(65, "carte_pirate_3_rouge", "rouge", 3, Properties.Resources.carte_pirate_3_rouge, Properties.Resources.carte_pirate_3_rouge_min);
            CartePirate pirateRouge3_4 = new CartePirate(66, "carte_pirate_3_rouge", "rouge", 3, Properties.Resources.carte_pirate_3_rouge, Properties.Resources.carte_pirate_3_rouge_min);

            CartePirate pirateJaune3_1 = new CartePirate(67, "carte_pirate_3_jaune", "jaune", 3, Properties.Resources.carte_pirate_3_jaune, Properties.Resources.carte_pirate_3_jaune_min);
            CartePirate pirateJaune3_2 = new CartePirate(68, "carte_pirate_3_jaune", "jaune", 3, Properties.Resources.carte_pirate_3_jaune, Properties.Resources.carte_pirate_3_jaune_min);
            CartePirate pirateJaune3_3 = new CartePirate(69, "carte_pirate_3_jaune", "jaune", 3, Properties.Resources.carte_pirate_3_jaune, Properties.Resources.carte_pirate_3_jaune_min);
            CartePirate pirateJaune3_4 = new CartePirate(70, "carte_pirate_3_jaune", "jaune", 3, Properties.Resources.carte_pirate_3_jaune, Properties.Resources.carte_pirate_3_jaune_min);



            CartePirate pirateBleu4_1 = new CartePirate(71, "carte_pirate_4_bleu", "bleu", 4, Properties.Resources.carte_pirate_4_bleu, Properties.Resources.carte_pirate_4_bleu_min);
            CartePirate pirateBleu4_2 = new CartePirate(72, "carte_pirate_4_bleu", "bleu", 4, Properties.Resources.carte_pirate_4_bleu, Properties.Resources.carte_pirate_4_bleu_min);

            CartePirate pirateVert4_1 = new CartePirate(73, "carte_pirate_4_vert", "vert", 4, Properties.Resources.carte_pirate_4_vert, Properties.Resources.carte_pirate_4_vert_min);
            CartePirate pirateVert4_2 = new CartePirate(74, "carte_pirate_4_vert", "vert", 4, Properties.Resources.carte_pirate_4_vert, Properties.Resources.carte_pirate_4_vert_min);

            CartePirate pirateRouge4_1 = new CartePirate(75, "carte_pirate_4_rouge", "rouge", 4, Properties.Resources.carte_pirate_4_rouge, Properties.Resources.carte_pirate_4_rouge_min);
            CartePirate pirateRouge4_2 = new CartePirate(76, "carte_pirate_4_rouge", "rouge", 4, Properties.Resources.carte_pirate_4_rouge, Properties.Resources.carte_pirate_4_rouge_min);

            CartePirate pirateJaune4_1 = new CartePirate(77, "carte_pirate_4_jaune", "jaune", 4, Properties.Resources.carte_pirate_4_jaune, Properties.Resources.carte_pirate_4_jaune_min);
            CartePirate pirateJaune4_2 = new CartePirate(78, "carte_pirate_4_jaune", "jaune", 4, Properties.Resources.carte_pirate_4_jaune, Properties.Resources.carte_pirate_4_jaune_min);

            _deck_pioche.Add(amiral.recuperer_idCarte(), amiral);
            _deck_pioche.Add(marchand2_1.recuperer_idCarte(), marchand2_1);
            _deck_pioche.Add(marchand2_2.recuperer_idCarte(), marchand2_2);
            _deck_pioche.Add(marchand2_3.recuperer_idCarte(), marchand2_3);
            _deck_pioche.Add(marchand2_4.recuperer_idCarte(), marchand2_4);
            _deck_pioche.Add(marchand2_5.recuperer_idCarte(), marchand2_5);
            _deck_pioche.Add(marchand3_1.recuperer_idCarte(), marchand3_1);
            _deck_pioche.Add(marchand3_2.recuperer_idCarte(), marchand3_2);
            _deck_pioche.Add(marchand3_3.recuperer_idCarte(), marchand3_3);
            _deck_pioche.Add(marchand3_4.recuperer_idCarte(), marchand3_4);
            _deck_pioche.Add(marchand3_5.recuperer_idCarte(), marchand3_5);
            _deck_pioche.Add(marchand3_6.recuperer_idCarte(), marchand3_6);
            _deck_pioche.Add(marchand4_1.recuperer_idCarte(), marchand4_1);
            _deck_pioche.Add(marchand4_2.recuperer_idCarte(), marchand4_2);
            _deck_pioche.Add(marchand4_3.recuperer_idCarte(), marchand4_3);
            _deck_pioche.Add(marchand4_4.recuperer_idCarte(), marchand4_4);
            _deck_pioche.Add(marchand4_5.recuperer_idCarte(), marchand4_4);
            _deck_pioche.Add(marchand5_1.recuperer_idCarte(), marchand5_1);
            _deck_pioche.Add(marchand5_2.recuperer_idCarte(), marchand5_2);
            _deck_pioche.Add(marchand5_3.recuperer_idCarte(), marchand5_3);
            _deck_pioche.Add(marchand5_4.recuperer_idCarte(), marchand5_4);
            _deck_pioche.Add(marchand5_5.recuperer_idCarte(), marchand5_5);
            _deck_pioche.Add(marchand6_1.recuperer_idCarte(), marchand6_1);
            _deck_pioche.Add(marchand6_2.recuperer_idCarte(), marchand6_2);
            _deck_pioche.Add(marchand7_1.recuperer_idCarte(), marchand7_1);
            _deck_pioche.Add(marchand8_1.recuperer_idCarte(), marchand8_1);



            _deck_pioche.Add(capitaineBleu.recuperer_idCarte(), capitaineBleu);
            _deck_pioche.Add(capitaineRouge.recuperer_idCarte(), capitaineRouge);
            _deck_pioche.Add(capitaineJaune.recuperer_idCarte(), capitaineJaune);
            _deck_pioche.Add(capitaineVert.recuperer_idCarte(), capitaineVert);


            _deck_pioche.Add(pirateBleu1_1.recuperer_idCarte(), pirateBleu1_1);
            _deck_pioche.Add(pirateBleu1_2.recuperer_idCarte(), pirateBleu1_2);

            _deck_pioche.Add(pirateVert1_1.recuperer_idCarte(), pirateVert1_1);
            _deck_pioche.Add(pirateVert1_2.recuperer_idCarte(), pirateVert1_2);

            _deck_pioche.Add(pirateRouge1_1.recuperer_idCarte(), pirateRouge1_1);
            _deck_pioche.Add(pirateRouge1_2.recuperer_idCarte(), pirateRouge1_2);

            _deck_pioche.Add(pirateJaune1_1.recuperer_idCarte(), pirateJaune1_1);
            _deck_pioche.Add(pirateJaune1_2.recuperer_idCarte(), pirateJaune1_2);


            _deck_pioche.Add(pirateBleu2_1.recuperer_idCarte(), pirateBleu2_1);
            _deck_pioche.Add(pirateBleu2_2.recuperer_idCarte(), pirateBleu2_2);
            _deck_pioche.Add(pirateBleu2_3.recuperer_idCarte(), pirateBleu2_3);
            _deck_pioche.Add(pirateBleu2_4.recuperer_idCarte(), pirateBleu2_4);


            _deck_pioche.Add(pirateVert2_1.recuperer_idCarte(), pirateVert2_1);
            _deck_pioche.Add(pirateVert2_2.recuperer_idCarte(), pirateVert2_2);
            _deck_pioche.Add(pirateVert2_3.recuperer_idCarte(), pirateVert2_3);
            _deck_pioche.Add(pirateVert2_4.recuperer_idCarte(), pirateVert2_4);

            _deck_pioche.Add(pirateRouge2_1.recuperer_idCarte(), pirateRouge2_1);
            _deck_pioche.Add(pirateRouge2_2.recuperer_idCarte(), pirateRouge2_2);
            _deck_pioche.Add(pirateRouge2_3.recuperer_idCarte(), pirateRouge2_3);
            _deck_pioche.Add(pirateRouge2_4.recuperer_idCarte(), pirateRouge2_4);


            _deck_pioche.Add(pirateJaune2_1.recuperer_idCarte(), pirateJaune2_1);
            _deck_pioche.Add(pirateJaune2_2.recuperer_idCarte(), pirateJaune2_2);
            _deck_pioche.Add(pirateJaune2_3.recuperer_idCarte(), pirateJaune2_3);
            _deck_pioche.Add(pirateJaune2_4.recuperer_idCarte(), pirateJaune2_4);


            _deck_pioche.Add(pirateBleu3_1.recuperer_idCarte(), pirateBleu3_1);
            _deck_pioche.Add(pirateBleu3_2.recuperer_idCarte(), pirateBleu3_2);
            _deck_pioche.Add(pirateBleu3_3.recuperer_idCarte(), pirateBleu3_3);
            _deck_pioche.Add(pirateBleu3_4.recuperer_idCarte(), pirateBleu3_4);

            _deck_pioche.Add(pirateVert3_1.recuperer_idCarte(), pirateVert3_1);
            _deck_pioche.Add(pirateVert3_2.recuperer_idCarte(), pirateVert3_2);
            _deck_pioche.Add(pirateVert3_3.recuperer_idCarte(), pirateVert3_3);
            _deck_pioche.Add(pirateVert3_4.recuperer_idCarte(), pirateVert3_4);

            _deck_pioche.Add(pirateRouge3_1.recuperer_idCarte(), pirateRouge3_1);
            _deck_pioche.Add(pirateRouge3_2.recuperer_idCarte(), pirateRouge3_2);
            _deck_pioche.Add(pirateRouge3_3.recuperer_idCarte(), pirateRouge3_3);
            _deck_pioche.Add(pirateRouge3_4.recuperer_idCarte(), pirateRouge3_4);

            _deck_pioche.Add(pirateJaune3_1.recuperer_idCarte(), pirateJaune3_1);
            _deck_pioche.Add(pirateJaune3_2.recuperer_idCarte(), pirateJaune3_2);
            _deck_pioche.Add(pirateJaune3_3.recuperer_idCarte(), pirateJaune3_3);
            _deck_pioche.Add(pirateJaune3_4.recuperer_idCarte(), pirateJaune3_4);

            _deck_pioche.Add(pirateBleu4_1.recuperer_idCarte(), pirateBleu4_1);
            _deck_pioche.Add(pirateBleu4_2.recuperer_idCarte(), pirateBleu4_2);

            _deck_pioche.Add(pirateVert4_1.recuperer_idCarte(), pirateVert4_1);
            _deck_pioche.Add(pirateVert4_2.recuperer_idCarte(), pirateVert4_2);

            _deck_pioche.Add(pirateRouge4_1.recuperer_idCarte(), pirateRouge4_1);
            _deck_pioche.Add(pirateRouge4_2.recuperer_idCarte(), pirateRouge4_2);

            _deck_pioche.Add(pirateJaune4_1.recuperer_idCarte(), pirateJaune4_1);
            _deck_pioche.Add(pirateJaune4_2.recuperer_idCarte(), pirateJaune4_2);

            _deck_base = _deck_pioche;
            _nombreCartesRestantes = _deck_pioche.Count;
        }

        public Dictionary<int, Carte> recuperer_deckPioche()
        {
            return _deck_pioche;
        }

        public void melanger_cartes()
        {
            Random _randNum = new Random();
            int _nombreCartes = _deck_pioche.Count;
            int _compteur = 0;

            Dictionary<int, Carte> _newDeck = new Dictionary<int, Carte>();
            Carte _carteTemporaire;

            int[] tableauID = new int[_nombreCartes];

            for (int i = 0; i < _nombreCartes; i++)
            {
                tableauID[i] = i + 1;
            }

            for (int i = 1; i <= _nombreCartes; i++)
            {
                bool jeton = false;
                do
                {
                    int _nombreAleatoire = _randNum.Next(79);


                    for (int j = 0; j < _nombreCartes; j++)
                    {
                        if (_nombreAleatoire == tableauID[j])
                        {
                            tableauID[j] = -1;
                            jeton = true;
                            ++_compteur;
                        }
                    }

                    if (jeton)
                    {
                        if (_deck_pioche.TryGetValue(_nombreAleatoire, out _carteTemporaire))
                        {
                            try
                            {
                                _newDeck.Add(i, _carteTemporaire);
                            }
                            catch (ArgumentException)
                            {
                                Console.WriteLine("_newDeck.Add(i, _temp); n'a pas marché");
                            }

                        }
                    }

                } while ((jeton == false) && (_compteur != _nombreCartes));


            }

            _deck_pioche = _newDeck;


        }

        public Carte piocher()
        {
            Carte carte = null;

            if(_nombreCartesRestantes != 0)
            {
                _deck_pioche.TryGetValue(_increment_piocheCarte, out carte);
                _deck_pioche.Remove(_increment_piocheCarte);
                _increment_piocheCarte++;
            }

            _nombreCartesRestantes = _deck_pioche.Count;

            return carte;
        }

        public Carte recuperer_carte_parID_deckBase(int idCarte)
        {
            foreach (var carte in _deck_base)
            {
                if(carte.Value.recuperer_idCarte() == idCarte)
                {
                    return carte.Value;
                }
            }

            return null;
        }

        public int recuperer_increment_deck()
        {
            return _increment_piocheCarte;
        }

        public int recuperer_nombre_cartes_deckPioche()
        {
            return _nombreCartesRestantes;
        }



    }
}
