using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DictionaryLibrary;

namespace DictionaryTests
{
    [TestClass]
    public class UnitTest1
    {
        private string testFilePath;

        [TestInitialize]
        public void Setup()
        {
            testFilePath = Path.GetTempFileName();
            File.WriteAllLines(testFilePath, new string[]
            {
                "сор",
                "мор",
                "хор",
                "сыр",
                "сон",
                "ворот",
                "ворон",
                "гром",
                "хром",
                "кот",
                "рот",
                "бот",
                "дом",
                "сом"
            });
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(testFilePath))
                File.Delete(testFilePath);
        }

        // ==================== ТЕСТЫ РАССТОЯНИЯ ЛЕВЕНШТЕЙНА ====================

        [TestMethod]
        public void TestLevenshteinDistance_IdenticalStrings_ReturnsZero()
        {
            int distance = Levenshtein.Distance("сор", "сор");
            Assert.AreEqual(0, distance);
        }

        [TestMethod]
        public void TestLevenshteinDistance_OneReplace_ReturnsOne()
        {
            int distance = Levenshtein.Distance("сор", "мор");
            Assert.AreEqual(1, distance);
        }

        [TestMethod]
        public void TestCanGetByOneReplace_TrueForOneReplace()
        {
            bool result = Levenshtein.CanGetByOneReplace("сор", "мор");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestCanGetByOneReplace_FalseForDifferentLength()
        {
            bool result = Levenshtein.CanGetByOneReplace("сор", "соры");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestCanGetByOneReplace_FalseForTwoReplaces()
        {
            bool result = Levenshtein.CanGetByOneReplace("сор", "мир");
            Assert.IsFalse(result);
        }

        // ==================== ТЕСТЫ СЛОВАРЯ ====================

        [TestMethod]
        public void TestDictionaryLoad_LoadsCorrectCount()
        {
            Dictionary dict = new Dictionary(testFilePath);
            Assert.AreEqual(14, dict.Count);
        }

        [TestMethod]
        public void TestDictionaryAdd_NewWord_AddsSuccessfully()
        {
            Dictionary dict = new Dictionary(testFilePath);
            bool result = dict.AddWord("лес");
            Assert.IsTrue(result);
            Assert.AreEqual(15, dict.Count);
        }

        [TestMethod]
        public void TestDictionaryAdd_ExistingWord_NotAdded()
        {
            Dictionary dict = new Dictionary(testFilePath);
            bool result = dict.AddWord("сор");
            Assert.IsFalse(result);
            Assert.AreEqual(14, dict.Count);
        }

        [TestMethod]
        public void TestDictionaryRemove_ExistingWord_Removed()
        {
            Dictionary dict = new Dictionary(testFilePath);
            bool result = dict.RemoveWord("сор");
            Assert.IsTrue(result);
            Assert.AreEqual(13, dict.Count);
        }

        [TestMethod]
        public void TestDictionaryRemove_NonExistingWord_NotRemoved()
        {
            Dictionary dict = new Dictionary(testFilePath);
            bool result = dict.RemoveWord("лес");
            Assert.IsFalse(result);
            Assert.AreEqual(14, dict.Count);
        }

        // ==================== ТЕСТЫ ПОИСКА ПО ВАРИАНТУ 20 ====================

        [TestMethod]
        public void TestWordFinder_FindWordsByOneReplace_SourceWordSor()
        {
            Dictionary dict = new Dictionary(testFilePath);
            WordFinder finder = new WordFinder(dict);

            List<string> results = finder.FindWordsByOneReplace("сор");

            // Ожидаемые слова: мор, хор, сыр, сон
            CollectionAssert.Contains(results, "мор");
            CollectionAssert.Contains(results, "хор");
            CollectionAssert.Contains(results, "сыр");
            CollectionAssert.Contains(results, "сон");
            Assert.AreEqual(4, results.Count);
        }

        [TestMethod]
        public void TestWordFinder_FindWordsByOneReplace_SourceWordVorot()
        {
            Dictionary dict = new Dictionary(testFilePath);
            WordFinder finder = new WordFinder(dict);

            List<string> results = finder.FindWordsByOneReplace("ворот");

            CollectionAssert.Contains(results, "ворон");
            Assert.AreEqual(1, results.Count);
        }

        [TestMethod]
        public void TestWordFinder_FindWordsByOneReplace_SourceWordGrom()
        {
            Dictionary dict = new Dictionary(testFilePath);
            WordFinder finder = new WordFinder(dict);

            List<string> results = finder.FindWordsByOneReplace("гром");

            CollectionAssert.Contains(results, "хром");
            Assert.AreEqual(1, results.Count);
        }

        [TestMethod]
        public void TestWordFinder_NoResults_ReturnsEmptyList()
        {
            Dictionary dict = new Dictionary(testFilePath);
            WordFinder finder = new WordFinder(dict);

            List<string> results = finder.FindWordsByOneReplace("абвгд");

            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestWordFinder_SearchResult_ReturnsSuccessFlag()
        {
            Dictionary dict = new Dictionary(testFilePath);
            WordFinder finder = new WordFinder(dict);

            SearchResult result = finder.SearchWithResult("сор");

            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public void TestWordFinder_SearchResult_NoResults_ReturnsFailure()
        {
            Dictionary dict = new Dictionary(testFilePath);
            WordFinder finder = new WordFinder(dict);

            SearchResult result = finder.SearchWithResult("абвгд");

            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(0, result.Count);
        }

        // ==================== ТЕСТЫ ДОПОЛНИТЕЛЬНЫЕ ====================

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestDictionaryLoad_InvalidFile_ThrowsException()
        {
            Dictionary dict = new Dictionary("nonexistent.txt");
        }

        [TestMethod]
        public void TestDictionary_FindWordsStartingWith()
        {
            Dictionary dict = new Dictionary(testFilePath);
            List<string> results = dict.FindWordsStartingWith("со");

            CollectionAssert.Contains(results, "сор");
            CollectionAssert.Contains(results, "сон");
            CollectionAssert.Contains(results, "сом");
        }

        [TestMethod]
        public void TestDictionary_GetWordsStartingWithLetter()
        {
            Dictionary dict = new Dictionary(testFilePath);
            List<string> results = dict.GetWordsStartingWithLetter('с');

            Assert.IsTrue(results.Count >= 3);
            CollectionAssert.Contains(results, "сор");
            CollectionAssert.Contains(results, "сыр");
            CollectionAssert.Contains(results, "сон");
        }
    }
}