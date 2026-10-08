
namespace DZ4_Latypova
{
     #region Структуры и перечисления

    /// <summary>
    /// Уровень ворчливости деда.
    /// </summary>
    public enum GrumpLevel
    {
        Low,
        Medium,
        High
    }

    /// <summary>
    /// Структура Дед.
    /// </summary>
    public struct Ded
    {
        public string Name;
        public GrumpLevel Level;
        public string[] Phrases;
        public int Bruises;

        /// <summary>
        /// Проверяет фразы деда на наличие матерных слов.
        /// Увеличивает количество фингалов и возвращает их число.
        /// </summary>
        public int CheckCurses(params string[] badWords)
        {
            int newBruises = 0;
            foreach (string phrase in Phrases)
            {
                foreach (string badWord in badWords)
                {
                    if (phrase.Contains(badWord, StringComparison.OrdinalIgnoreCase))
                    {
                        newBruises++;
                    }
                }
            }
            Bruises += newBruises;
            return newBruises;
        }
    }
    #endregion Потрачено

}