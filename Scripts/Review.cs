 [System.Serializable]
 public class Review
        {
         public string author;
        public string highlight;
        public string review;
        public int stars;
        public int tag;

        public bool selected;

    public Review(string author, string highlight, string review, int stars, int tag){

        this.author  = author;
        this.highlight = highlight;
        this.review = review;
        this.stars = stars;
        this.tag = tag;
    }


    }