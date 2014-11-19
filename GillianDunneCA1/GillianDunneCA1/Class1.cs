// Gillian Dunne - X00094469
// American spelling used to keep code analysis happy :)
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
[assembly: CLSCompliant(true)]
namespace GillianDunneCA1
{
    public class Favorite {
        private String name;
        Uri uri;
        public String Name {
            get {
                return name;
            }
            set {
                if (String.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Name cannot be blank");
                }
                else {
                    name = value;
                }
            }
        }

        public Uri Uri {
            get {
                return uri;
            }
            set { // Validate URI - Uri.IsWellFormedUriString(uri, UriKind.RelativeOrAbsolute)
                if (true) {
                    uri = value;
                }
                else {
                    throw new ArgumentException("Invalid URI");
                }
            }
        }

        public Favorite(String name, Uri uri) {
            this.Name = name;
            this.Uri = uri;
        }

        public override string ToString() {
            return "Name: " + name + "\tUri" + uri;
        }
    }

    public class FavoritesCollection : IEnumerable {
        private List<Favorite> favoriteList = new List<Favorite>();
        public Collection<Favorite> FavoriteList {
            get {
                return new Collection<Favorite>(favoriteList);
            }
        }

        public void AddFavorite(Favorite favorite) {
            if (FavoriteList == null) {
                favoriteList.Add(favorite);
            }
            else {
                bool duplicate = false;
                foreach (Favorite f in favoriteList) {
                    if ((favorite.Name == f.Name) && (favorite.Uri == f.Uri)) {
                        duplicate = true;
                        break;
                    }
                }
                if (duplicate == true) {
                    throw new ArgumentException("Favorite already in list");
                }
                else {
                    favoriteList.Add(favorite);
                }
            }
        }

        public IEnumerator GetEnumerator() {
            foreach (Favorite f in favoriteList) {
                yield return f;
            }
        }

        public void RemoveFavorite(String favorite) {
            if (FavoriteList == null) {
                throw new ArgumentException("List is empty");
            }
            else {
                for (int i = 0; i < FavoriteList.Count; i++ ) {
                    if (FavoriteList[i].Name.Equals(favorite)) {
                        favoriteList.Remove(FavoriteList[i]);
                    }
                    else {
                        throw new ArgumentException("Favorite not found");
                    }
                }
            }
        }

        public Favorite this[String favoriteName] {
            get {
                Favorite favorite = null;
                bool isFound = false;
                for (int i = 0; i < favoriteList.Count; i++) {
                    if (String.Compare(favoriteList[i].Name, favoriteName, StringComparison.OrdinalIgnoreCase) == 0) {
                        isFound = true;
                        favorite = favoriteList[i];
                    }
                }
                if (isFound == true) {
                    return favorite;
                }
                else {
                    throw new ArgumentException("Favorite not found");
                }
            }
        }

        public void SortFavorite() {
            var favorites = favoriteList.OrderBy(f => f.Name).ToList();
        }
    }
}
