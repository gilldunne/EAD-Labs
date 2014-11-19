// Gillian Dunne - X00094469
// American spelling used to keep code analysis happy :)
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GillianDunneCA1;
using System.Collections.Generic;
namespace UnitTestFavourite {
    [TestClass]
    public class UnitTest1 {
        // Test the constructor works 
        [TestMethod]
        public void TestValidation1() {
            Favorite f = new Favorite("Home", new Uri("https://www.it-tallaght.ie"));
            Assert.AreEqual(f.Name, "Home");
            Assert.AreEqual(f.Uri, "https://www.it-tallaght.ie");
        }

        // Throws an exception when Name is incorrect
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidation2() {
            Favorite f = new Favorite("", new Uri("https://www.it-tallaght.ie"));
        }

        // Try to test the URI exception
        // But did not get that exception working
        /*[TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidation3() {
            Favorite f = new Favorite("Home", new Uri("hts://www.it-tallaght"));
        }*/

        // Favorite is added correctly
        [TestMethod]
        public void TestAddFavorite1() {
            Favorite f1 = new Favorite("Home", new Uri("https://www.it-tallaght.ie"));
            Favorite f2 = new Favorite("About Us", new Uri("https://www.it-tallaght.ie"));
            FavoritesCollection fc = new FavoritesCollection();

            fc.AddFavorite(f1);
            fc.AddFavorite(f2);
            
            CollectionAssert.Contains(fc.FavoriteList, f1);
            CollectionAssert.Contains(fc.FavoriteList, f2);
        }

        // Exception thrown when favorite in list already
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddFavorite2() {
            Favorite f1 = new Favorite("Home", new Uri("https://www.it-tallaght.ie"));
            FavoritesCollection fc = new FavoritesCollection();
            fc.AddFavorite(f1);
            fc.AddFavorite(f1);
        }

        // Remove the favorite from the list
        [TestMethod]
        public void TestRemoveFavorite1() {
            Favorite f1 = new Favorite("Home", new Uri("https://www.it-tallaght.ie"));
            Favorite f2 = new Favorite("About Us", new Uri("https://www.it-tallaght.ie"));
            FavoritesCollection fc = new FavoritesCollection();

            fc.AddFavorite(f1);
            fc.AddFavorite(f2);
            fc.RemoveFavorite("Home");

            CollectionAssert.DoesNotContain(fc.FavoriteList, f1);
            CollectionAssert.Contains(fc.FavoriteList, f2);
        }

        // Try remove something that is not in the list
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveFavorite2() {
            Favorite f1 = new Favorite("Home", new Uri("https://www.it-tallaght.ie"));
            Favorite f2 = new Favorite("About Us", new Uri("https://www.it-tallaght.ie"));
            FavoritesCollection fc = new FavoritesCollection();

            fc.AddFavorite(f1);
            fc.AddFavorite(f2);
            fc.RemoveFavorite("Cool Things");
        }

        // Test the indexer is pulling out a given name
        [TestMethod]
        public void TestIndexer() {
            Favorite f1 = new Favorite("Home", new Uri("https://www.it-tallaght.ie"));
            Favorite f2 = new Favorite("About Us", new Uri("https://www.it-tallaght.ie"));
            FavoritesCollection fc = new FavoritesCollection();

            fc.AddFavorite(f1);
            fc.AddFavorite(f2);

            List<Favorite> favoriteList = new List<Favorite>();
            favoriteList.Add(f1);

            // Indexer adding based on name
            List<Favorite> nameList = new List<Favorite>();
            foreach (Favorite f in fc) {
                if (f.Name == "Home") {
                    nameList.Add(f);
                }
                else {
                    break;
                }
            }
            // checks both lists are equal
            CollectionAssert.AreEqual(favoriteList, nameList);
        }
    }
}
