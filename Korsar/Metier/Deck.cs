using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class Deck
    {
        private int _nbCartesRestantes;
        private Dictionary<int, Carte> _deck;

        private int _indexCarte = 1;

        private int _forceCapitaine = 15;
        private int _forceAmiral = 20;

        public Deck()
        {
            _deck = new Dictionary<int, Carte>();
            CarteAmiral amiral = new CarteAmiral(1, "carte_amiral", _forceAmiral, Properties.Resources.carte_amiral);

            CarteMarchand marchand2_1 = new CarteMarchand(2, "carte_marchand_2", 2, Properties.Resources.carte_marchand_2);
            CarteMarchand marchand2_2 = new CarteMarchand(3, "carte_marchand_2", 2, Properties.Resources.carte_marchand_2);
            CarteMarchand marchand2_3 = new CarteMarchand(4, "carte_marchand_2", 2, Properties.Resources.carte_marchand_2);
            CarteMarchand marchand2_4 = new CarteMarchand(5, "carte_marchand_2", 2, Properties.Resources.carte_marchand_2);
            CarteMarchand marchand2_5 = new CarteMarchand(6, "carte_marchand_2", 2, Properties.Resources.carte_marchand_2);

            CarteMarchand marchand3_1 = new CarteMarchand(7, "carte_marchand_3", 3, Properties.Resources.carte_marchand_3);
            CarteMarchand marchand3_2 = new CarteMarchand(8, "carte_marchand_3", 3, Properties.Resources.carte_marchand_3);
            CarteMarchand marchand3_3 = new CarteMarchand(9, "carte_marchand_3", 3, Properties.Resources.carte_marchand_3);
            CarteMarchand marchand3_4 = new CarteMarchand(10, "carte_marchand_3", 3, Properties.Resources.carte_marchand_3);
            CarteMarchand marchand3_5 = new CarteMarchand(11, "carte_marchand_3", 3, Properties.Resources.carte_marchand_3);
            CarteMarchand marchand3_6 = new CarteMarchand(12, "carte_marchand_3", 3, Properties.Resources.carte_marchand_3);

            CarteMarchand marchand4_1 = new CarteMarchand(13, "carte_marchand_4", 4, Properties.Resources.carte_marchand_4);
            CarteMarchand marchand4_2 = new CarteMarchand(14, "carte_marchand_4", 4, Properties.Resources.carte_marchand_4);
            CarteMarchand marchand4_3 = new CarteMarchand(15, "carte_marchand_4", 4, Properties.Resources.carte_marchand_4);
            CarteMarchand marchand4_4 = new CarteMarchand(16, "carte_marchand_4", 4, Properties.Resources.carte_marchand_4);
            CarteMarchand marchand4_5 = new CarteMarchand(17, "carte_marchand_4", 4, Properties.Resources.carte_marchand_4);

            CarteMarchand marchand5_1 = new CarteMarchand(18, "carte_marchand_5", 5, Properties.Resources.carte_marchand_5);
            CarteMarchand marchand5_2 = new CarteMarchand(19, "carte_marchand_5", 5, Properties.Resources.carte_marchand_5);
            CarteMarchand marchand5_3 = new CarteMarchand(20, "carte_marchand_5", 5, Properties.Resources.carte_marchand_5);
            CarteMarchand marchand5_4 = new CarteMarchand(21, "carte_marchand_5", 5, Properties.Resources.carte_marchand_5);
            CarteMarchand marchand5_5 = new CarteMarchand(22, "carte_marchand_5", 5, Properties.Resources.carte_marchand_5);


            CarteMarchand marchand6_1 = new CarteMarchand(23, "carte_marchand_6", 6, Properties.Resources.carte_marchand_6);
            CarteMarchand marchand6_2 = new CarteMarchand(24, "carte_marchand_6", 6, Properties.Resources.carte_marchand_6);

            CarteMarchand marchand7_1 = new CarteMarchand(25, "carte_marchand_7", 7, Properties.Resources.carte_marchand_7);
            CarteMarchand marchand8_1 = new CarteMarchand(26, "carte_marchand_8", 8, Properties.Resources.carte_marchand_8);

            CarteCapitaine capitaineBleu = new CarteCapitaine(27, "carte_capitaine_bleu", "bleu", _forceCapitaine, Properties.Resources.carte_capitaine_bleu);
            CarteCapitaine capitaineRouge = new CarteCapitaine(28, "carte_capitaine_rouge", "rouge", _forceCapitaine, Properties.Resources.carte_capitaine_rouge);
            CarteCapitaine capitaineJaune = new CarteCapitaine(29, "carte_capitaine_jaune", "jaune", _forceCapitaine, Properties.Resources.carte_capitaine_jaune);
            CarteCapitaine capitaineVert = new CarteCapitaine(30, "carte_capitaine_vert", "vert", _forceCapitaine, Properties.Resources.carte_capitaine_vert);

            CartePirate pirateBleu1_1 = new CartePirate(31, "carte_pirate_1_bleu", "bleu", 1, Properties.Resources.carte_pirate_1_bleu);
            CartePirate pirateBleu1_2 = new CartePirate(32, "carte_pirate_1_bleu", "bleu", 1, Properties.Resources.carte_pirate_1_bleu);

            CartePirate pirateVert1_1 = new CartePirate(33, "carte_pirate_1_vert", "vert", 1, Properties.Resources.carte_pirate_1_vert);
            CartePirate pirateVert1_2 = new CartePirate(34, "carte_pirate_1_vert", "vert", 1, Properties.Resources.carte_pirate_1_vert);

            CartePirate pirateRouge1_1 = new CartePirate(35, "carte_pirate_1_rouge", "rouge", 1, Properties.Resources.carte_pirate_1_rouge);
            CartePirate pirateRouge1_2 = new CartePirate(36, "carte_pirate_1_rouge", "rouge", 1, Properties.Resources.carte_pirate_1_rouge);

            CartePirate pirateJaune1_1 = new CartePirate(37, "carte_pirate_1_jaune", "jaune", 1, Properties.Resources.carte_pirate_1_jaune);
            CartePirate pirateJaune1_2 = new CartePirate(38, "carte_pirate_1_jaune", "jaune", 1, Properties.Resources.carte_pirate_1_jaune);


            CartePirate pirateBleu2_1 = new CartePirate(39, "carte_pirate_2_bleu", "bleu", 2, Properties.Resources.carte_pirate_2_bleu);
            CartePirate pirateBleu2_2 = new CartePirate(40, "carte_pirate_2_bleu", "bleu", 2, Properties.Resources.carte_pirate_2_bleu);
            CartePirate pirateBleu2_3 = new CartePirate(41, "carte_pirate_2_bleu", "bleu", 2, Properties.Resources.carte_pirate_2_bleu);
            CartePirate pirateBleu2_4 = new CartePirate(42, "carte_pirate_2_bleu", "bleu", 2, Properties.Resources.carte_pirate_2_bleu);

            CartePirate pirateVert2_1 = new CartePirate(43, "carte_pirate_2_vert", "vert", 2, Properties.Resources.carte_pirate_2_vert);
            CartePirate pirateVert2_2 = new CartePirate(44, "carte_pirate_2_vert", "vert", 2, Properties.Resources.carte_pirate_2_vert);
            CartePirate pirateVert2_3 = new CartePirate(45, "carte_pirate_2_vert", "vert", 2, Properties.Resources.carte_pirate_2_vert);
            CartePirate pirateVert2_4 = new CartePirate(46, "carte_pirate_2_vert", "vert", 2, Properties.Resources.carte_pirate_2_vert);

            CartePirate pirateRouge2_1 = new CartePirate(47, "carte_pirate_2_rouge", "rouge", 2, Properties.Resources.carte_pirate_2_rouge);
            CartePirate pirateRouge2_2 = new CartePirate(48, "carte_pirate_2_rouge", "rouge", 2, Properties.Resources.carte_pirate_2_rouge);
            CartePirate pirateRouge2_3 = new CartePirate(49, "carte_pirate_2_rouge", "rouge", 2, Properties.Resources.carte_pirate_2_rouge);
            CartePirate pirateRouge2_4 = new CartePirate(50, "carte_pirate_2_rouge", "rouge", 2, Properties.Resources.carte_pirate_2_rouge);

            CartePirate pirateJaune2_1 = new CartePirate(51, "carte_pirate_2_jaune", "jaune", 2, Properties.Resources.carte_pirate_2_jaune);
            CartePirate pirateJaune2_2 = new CartePirate(52, "carte_pirate_2_jaune", "jaune", 2, Properties.Resources.carte_pirate_2_jaune);
            CartePirate pirateJaune2_3 = new CartePirate(53, "carte_pirate_2_jaune", "jaune", 2, Properties.Resources.carte_pirate_2_jaune);
            CartePirate pirateJaune2_4 = new CartePirate(54, "carte_pirate_2_jaune", "jaune", 2, Properties.Resources.carte_pirate_2_jaune);



            CartePirate pirateBleu3_1 = new CartePirate(55, "carte_pirate_3_bleu", "bleu", 3, Properties.Resources.carte_pirate_3_bleu);
            CartePirate pirateBleu3_2 = new CartePirate(56, "carte_pirate_3_bleu", "bleu", 3, Properties.Resources.carte_pirate_3_bleu);
            CartePirate pirateBleu3_3 = new CartePirate(57, "carte_pirate_3_bleu", "bleu", 3, Properties.Resources.carte_pirate_3_bleu);
            CartePirate pirateBleu3_4 = new CartePirate(58, "carte_pirate_3_bleu", "bleu", 3, Properties.Resources.carte_pirate_3_bleu);

            CartePirate pirateVert3_1 = new CartePirate(59, "carte_pirate_3_vert", "vert", 3, Properties.Resources.carte_pirate_3_vert);
            CartePirate pirateVert3_2 = new CartePirate(60, "carte_pirate_3_vert", "vert", 3, Properties.Resources.carte_pirate_3_vert);
            CartePirate pirateVert3_3 = new CartePirate(61, "carte_pirate_3_vert", "vert", 3, Properties.Resources.carte_pirate_3_vert);
            CartePirate pirateVert3_4 = new CartePirate(62, "carte_pirate_3_vert", "vert", 3, Properties.Resources.carte_pirate_3_vert);

            CartePirate pirateRouge3_1 = new CartePirate(63, "carte_pirate_3_rouge", "rouge", 3, Properties.Resources.carte_pirate_3_rouge);
            CartePirate pirateRouge3_2 = new CartePirate(64, "carte_pirate_3_rouge", "rouge", 3, Properties.Resources.carte_pirate_3_rouge);
            CartePirate pirateRouge3_3 = new CartePirate(65, "carte_pirate_3_rouge", "rouge", 3, Properties.Resources.carte_pirate_3_rouge);
            CartePirate pirateRouge3_4 = new CartePirate(66, "carte_pirate_3_rouge", "rouge", 3, Properties.Resources.carte_pirate_3_rouge);

            CartePirate pirateJaune3_1 = new CartePirate(67, "carte_pirate_3_jaune", "jaune", 3, Properties.Resources.carte_pirate_3_jaune);
            CartePirate pirateJaune3_2 = new CartePirate(68, "carte_pirate_3_jaune", "jaune", 3, Properties.Resources.carte_pirate_3_jaune);
            CartePirate pirateJaune3_3 = new CartePirate(69, "carte_pirate_3_jaune", "jaune", 3, Properties.Resources.carte_pirate_3_jaune);
            CartePirate pirateJaune3_4 = new CartePirate(70, "carte_pirate_3_jaune", "jaune", 3, Properties.Resources.carte_pirate_3_jaune);



            CartePirate pirateBleu4_1 = new CartePirate(71, "carte_pirate_4_bleu", "bleu", 4, Properties.Resources.carte_pirate_4_bleu);
            CartePirate pirateBleu4_2 = new CartePirate(72, "carte_pirate_4_bleu", "bleu", 4, Properties.Resources.carte_pirate_4_bleu);

            CartePirate pirateVert4_1 = new CartePirate(73, "carte_pirate_4_vert", "vert", 4, Properties.Resources.carte_pirate_4_vert);
            CartePirate pirateVert4_2 = new CartePirate(74, "carte_pirate_4_vert", "vert", 4, Properties.Resources.carte_pirate_4_vert);

            CartePirate pirateRouge4_1 = new CartePirate(75, "carte_pirate_4_rouge", "rouge", 4, Properties.Resources.carte_pirate_4_rouge);
            CartePirate pirateRouge4_2 = new CartePirate(76, "carte_pirate_4_rouge", "rouge", 4, Properties.Resources.carte_pirate_4_rouge);

            CartePirate pirateJaune4_1 = new CartePirate(77, "carte_pirate_4_jaune", "jaune", 4, Properties.Resources.carte_pirate_4_jaune);
            CartePirate pirateJaune4_2 = new CartePirate(78, "carte_pirate_4_jaune", "jaune", 4, Properties.Resources.carte_pirate_4_jaune);

            _deck.Add(amiral.getIdCarte(), amiral);
            _deck.Add(marchand2_1.getIdCarte(), marchand2_1);
            _deck.Add(marchand2_2.getIdCarte(), marchand2_2);
            _deck.Add(marchand2_3.getIdCarte(), marchand2_3);
            _deck.Add(marchand2_4.getIdCarte(), marchand2_4);
            _deck.Add(marchand2_5.getIdCarte(), marchand2_5);
            _deck.Add(marchand3_1.getIdCarte(), marchand3_1);
            _deck.Add(marchand3_2.getIdCarte(), marchand3_2);
            _deck.Add(marchand3_3.getIdCarte(), marchand3_3);
            _deck.Add(marchand3_4.getIdCarte(), marchand3_4);
            _deck.Add(marchand3_5.getIdCarte(), marchand3_5);
            _deck.Add(marchand3_6.getIdCarte(), marchand3_6);
            _deck.Add(marchand4_1.getIdCarte(), marchand4_1);
            _deck.Add(marchand4_2.getIdCarte(), marchand4_2);
            _deck.Add(marchand4_3.getIdCarte(), marchand4_3);
            _deck.Add(marchand4_4.getIdCarte(), marchand4_4);
            _deck.Add(marchand4_5.getIdCarte(), marchand4_4);
            _deck.Add(marchand5_1.getIdCarte(), marchand5_1);
            _deck.Add(marchand5_2.getIdCarte(), marchand5_2);
            _deck.Add(marchand5_3.getIdCarte(), marchand5_3);
            _deck.Add(marchand5_4.getIdCarte(), marchand5_4);
            _deck.Add(marchand5_5.getIdCarte(), marchand5_5);
            _deck.Add(marchand6_1.getIdCarte(), marchand6_1);
            _deck.Add(marchand6_2.getIdCarte(), marchand6_2);
            _deck.Add(marchand7_1.getIdCarte(), marchand7_1);
            _deck.Add(marchand8_1.getIdCarte(), marchand8_1);



            _deck.Add(capitaineBleu.getIdCarte(), capitaineBleu);
            _deck.Add(capitaineRouge.getIdCarte(), capitaineRouge);
            _deck.Add(capitaineJaune.getIdCarte(), capitaineJaune);
            _deck.Add(capitaineVert.getIdCarte(), capitaineVert);


            _deck.Add(pirateBleu1_1.getIdCarte(), pirateBleu1_1);
            _deck.Add(pirateBleu1_2.getIdCarte(), pirateBleu1_2);

            _deck.Add(pirateVert1_1.getIdCarte(), pirateVert1_1);
            _deck.Add(pirateVert1_2.getIdCarte(), pirateVert1_2);

            _deck.Add(pirateRouge1_1.getIdCarte(), pirateRouge1_1);
            _deck.Add(pirateRouge1_2.getIdCarte(), pirateRouge1_2);

            _deck.Add(pirateJaune1_1.getIdCarte(), pirateJaune1_1);
            _deck.Add(pirateJaune1_2.getIdCarte(), pirateJaune1_2);


            _deck.Add(pirateBleu2_1.getIdCarte(), pirateBleu2_1);
            _deck.Add(pirateBleu2_2.getIdCarte(), pirateBleu2_2);
            _deck.Add(pirateBleu2_3.getIdCarte(), pirateBleu2_3);
            _deck.Add(pirateBleu2_4.getIdCarte(), pirateBleu2_4);


            _deck.Add(pirateVert2_1.getIdCarte(), pirateVert2_1);
            _deck.Add(pirateVert2_2.getIdCarte(), pirateVert2_2);
            _deck.Add(pirateVert2_3.getIdCarte(), pirateVert2_3);
            _deck.Add(pirateVert2_4.getIdCarte(), pirateVert2_4);

            _deck.Add(pirateRouge2_1.getIdCarte(), pirateRouge2_1);
            _deck.Add(pirateRouge2_2.getIdCarte(), pirateRouge2_2);
            _deck.Add(pirateRouge2_3.getIdCarte(), pirateRouge2_3);
            _deck.Add(pirateRouge2_4.getIdCarte(), pirateRouge2_4);


            _deck.Add(pirateJaune2_1.getIdCarte(), pirateJaune2_1);
            _deck.Add(pirateJaune2_2.getIdCarte(), pirateJaune2_2);
            _deck.Add(pirateJaune2_3.getIdCarte(), pirateJaune2_3);
            _deck.Add(pirateJaune2_4.getIdCarte(), pirateJaune2_4);


            _deck.Add(pirateBleu3_1.getIdCarte(), pirateBleu3_1);
            _deck.Add(pirateBleu3_2.getIdCarte(), pirateBleu3_2);
            _deck.Add(pirateBleu3_3.getIdCarte(), pirateBleu3_3);
            _deck.Add(pirateBleu3_4.getIdCarte(), pirateBleu3_4);

            _deck.Add(pirateVert3_1.getIdCarte(), pirateVert3_1);
            _deck.Add(pirateVert3_2.getIdCarte(), pirateVert3_2);
            _deck.Add(pirateVert3_3.getIdCarte(), pirateVert3_3);
            _deck.Add(pirateVert3_4.getIdCarte(), pirateVert3_4);

            _deck.Add(pirateRouge3_1.getIdCarte(), pirateRouge3_1);
            _deck.Add(pirateRouge3_2.getIdCarte(), pirateRouge3_2);
            _deck.Add(pirateRouge3_3.getIdCarte(), pirateRouge3_3);
            _deck.Add(pirateRouge3_4.getIdCarte(), pirateRouge3_4);

            _deck.Add(pirateJaune3_1.getIdCarte(), pirateJaune3_1);
            _deck.Add(pirateJaune3_2.getIdCarte(), pirateJaune3_2);
            _deck.Add(pirateJaune3_3.getIdCarte(), pirateJaune3_3);
            _deck.Add(pirateJaune3_4.getIdCarte(), pirateJaune3_4);

            _deck.Add(pirateBleu4_1.getIdCarte(), pirateBleu4_1);
            _deck.Add(pirateBleu4_2.getIdCarte(), pirateBleu4_2);

            _deck.Add(pirateVert4_1.getIdCarte(), pirateVert4_1);
            _deck.Add(pirateVert4_2.getIdCarte(), pirateVert4_2);

            _deck.Add(pirateRouge4_1.getIdCarte(), pirateRouge4_1);
            _deck.Add(pirateRouge4_2.getIdCarte(), pirateRouge4_2);

            _deck.Add(pirateJaune4_1.getIdCarte(), pirateJaune4_1);
            _deck.Add(pirateJaune4_2.getIdCarte(), pirateJaune4_2);


        }

        public Dictionary<int, Carte> getDeck()
        {
            return _deck;
        }

        public void melangerCartes()
        {
            Random _randNum = new Random();
            int _nbCartes = _deck.Count;
            int _compteur = 0;

            Dictionary<int, Carte> _newDeck = new Dictionary<int, Carte>();
            Carte _temp;

            int[] tableauID = new int[_nbCartes];

            for (int i = 0; i < _nbCartes; i++)
            {
                tableauID[i] = i + 1;
            }

            for (int i = 1; i <= _nbCartes; i++)
            {
                bool jeton = false;
                do
                {
                    int _nombrAleatoire = _randNum.Next(79);


                    for (int j = 0; j < _nbCartes; j++)
                    {
                        if (_nombrAleatoire == tableauID[j])
                        {
                            tableauID[j] = -1;
                            jeton = true;
                            ++_compteur;
                        }
                    }

                    if (jeton)
                    {
                        if (_deck.TryGetValue(_nombrAleatoire, out _temp))
                        {
                            try
                            {
                                _newDeck.Add(i, _temp);
                            }
                            catch (ArgumentException)
                            {
                                Console.WriteLine("_newDeck.Add(i, _temp); n'a pas marché");
                            }

                        }
                    }

                } while ((jeton == false) && (_compteur != _nbCartes));


            }

            _deck = _newDeck;


        }

        public Carte piocher()
        {
            Carte carte;

            _deck.TryGetValue(_indexCarte, out carte);
            _deck.Remove(_indexCarte);
            _indexCarte++;

            return carte;
        }

        public Carte getCarteByNom(string nom)
        {
            foreach (var carte in _deck)
            {
                if(carte.Value.afficherNomCarte() == nom)
                {
                    return carte.Value;
                }
            }

            return null;
        }

        public int getIndex()
        {
            return _indexCarte;
        }

        public int getNombreCartes()
        {
            return _deck.Count;
        }



    }
}
