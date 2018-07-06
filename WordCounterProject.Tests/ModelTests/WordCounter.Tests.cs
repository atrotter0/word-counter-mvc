using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WordCounterProject.Models;

namespace WordCounterProject.Tests
{
    [TestClass]
    public class WordCounterTests
    {
        [TestMethod]
        public void GetSetUserWord_GetsSetsUserWord_String()
        {
            WordCounter newCounter = new WordCounter();
            newCounter.SetUserWord("dog");
            Assert.AreEqual("dog", newCounter.GetUserWord());
        }

        [TestMethod]
        public void GetSetUserPhrase_GetsSetsUserPhrase_String()
        {
            WordCounter newCounter = new WordCounter();
            string phrase = "This is the end, the end my friend.";
            newCounter.SetUserPhrase(phrase);
            Assert.AreEqual(phrase, newCounter.GetUserPhrase());
        }

        [TestMethod]
        public void GetSetScrubbedPhrase_GetsSetsScrubbedPhrase_String()
        {
            WordCounter newCounter = new WordCounter();
            newCounter.SetScrubbedPhrase("this is the end the end my friend");
            Assert.AreEqual("this is the end the end my friend", newCounter.GetScrubbedPhrase());
        }

        [TestMethod]
        public void GetIncrementWordCount_GetsAndIncrementsWordCount_Int()
        {
            WordCounter newCounter = new WordCounter();
            newCounter.IncrementWordCount();
            Assert.AreEqual(1, newCounter.GetWordCount());
        }

        [TestMethod]
        public void ResetWordCount_ResetsWordCount_Int()
        {
            WordCounter newCounter = new WordCounter();
            newCounter.IncrementWordCount();
            newCounter.IncrementWordCount();
            newCounter.ResetWordCount();
            Assert.AreEqual(0, newCounter.GetWordCount());
        }

        [TestMethod]
        public void IsNullWord_ChecksForNullInput_True()
        {
            WordCounter newCounter = new WordCounter();
            string word = null;
            Assert.AreEqual(true, newCounter.IsNullWord(word));
        }

        [TestMethod]
        public void IsValidWord_ChecksWordForInvalidCharacters_False()
        {
            WordCounter newCounter = new WordCounter();
            string input = "%$DHOG&*";
            Assert.AreEqual(false, newCounter.IsValidWord(input));
        }

        [TestMethod]
        public void IsValidWord_ChecksWordForInvalidCharacters_True()
        {
            WordCounter newCounter = new WordCounter();
            string input = "cat";
            Assert.AreEqual(true, newCounter.IsValidWord(input));
        }

        [TestMethod]
        public void DowncaseAndTrimWord_DowncasesAndTrimsWord_String()
        {
            WordCounter newCounter = new WordCounter();
            newCounter.SetUserWord("  DOG  ");
            newCounter.DowncaseAndTrimWord();
            Assert.AreEqual("dog", newCounter.GetUserWord());
        }

        [TestMethod]
        public void DowncaseAndScrubPhrase_DowncasesUserPhrase_String()
        {
            WordCounter newCounter = new WordCounter();
            string phrase = "This is the end, the END my friend.";
            newCounter.SetUserPhrase(phrase);
            newCounter.DowncaseAndScrubPhrase();
            string expectedOutput = "this is the end the end my friend";
            Assert.AreEqual(expectedOutput, newCounter.GetScrubbedPhrase());
        }

        [TestMethod]
        public void ScrubPunctuation_RemovesPunctuationFromString_String()
        {
            WordCounter newCounter = new WordCounter();
            string phraseWithPunctuation = "This is the end, the end my friend!";
            string stripped = "This is the end the end my friend";
            Assert.AreEqual(stripped, newCounter.ScrubPunctuation(phraseWithPunctuation));
        }

        [TestMethod]
        public void AddLettersAndSpaces_AddsLettersAndSpacesToList_CharList()
        {
            WordCounter newCounter = new WordCounter();
            List<char> expectedLetterList = new List<char>() { 'a' };
            List<char> testLetterList = new List<char>() {};
            List<char> expectedSpaceList = new List<char>() { ' ' };
            List<char> testSpaceList = new List<char>() {};

            newCounter.AddLettersAndSpaces('a', testLetterList);
            newCounter.AddLettersAndSpaces(' ', testSpaceList);
            CollectionAssert.AreEqual(expectedLetterList, testLetterList);
            CollectionAssert.AreEqual(expectedSpaceList, testSpaceList);
        }

        [TestMethod]
        public void FindWordMatches_CountsUserWordInPhrase_Int()
        {
            WordCounter newCounter = new WordCounter();
            newCounter.SetUserWord("goblins");
            newCounter.SetScrubbedPhrase("the goblins are everywhere dont get surrounded by the goblins");
            newCounter.FindWordMatches();
            Assert.AreEqual(2, newCounter.GetWordCount());
        }

        [TestMethod]
        public void IncrementIfWordMatch_ChecksIfWordMatchesWordsInPhrase_True()
        {
            WordCounter newCounter = new WordCounter();
            string word = "elf";
            newCounter.SetUserWord("elf");
            newCounter.IncrementIfWordMatch(word);
            Assert.AreEqual(1, newCounter.GetWordCount());
        }

        [TestMethod]
        public void InvalidWordOrPhrase_ChecksForSpecialCharsInWord_True()
        {
            WordCounter newCounter = new WordCounter();
            newCounter.SetUserWord("elf&^");
            Assert.AreEqual(true, newCounter.InvalidWordOrPhrase());
        }

        [TestMethod]
        public void InvalidWordOrPhrase_ChecksForNullWord_True()
        {
            WordCounter newCounter = new WordCounter();
            newCounter.SetUserWord(null);
            Assert.AreEqual(true, newCounter.InvalidWordOrPhrase());
        }

        // [TestMethod]
        // public void GetSetError_GetsSetsError_True()
        // {
        //     WordCounter newCounter = new WordCounter();
        //     newCounter.SetUserWord("");
        // }
    }
}
