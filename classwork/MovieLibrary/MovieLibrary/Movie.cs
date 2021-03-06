using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary
{
    //Naming rules for class
    // 1. Pascal cased
    // 2. Never prefix with T, C or anything else
    // 3. Noun - because they represent an object/entity in your system

    /// <summary> Represents a movie. </summary>
    public class Movie //: IValidatableObject
    {
        // Default constructor
        public Movie ()
        { }

        public Movie (string title) : this(0, title)
        {
            //Initialize(title);
            //Title = title;
        }

        public Movie (int id, string title) : this()
        {
            Id = id;
            //Initialize(title);
            Title = title;
        }

        //Shared inti but dangerous to use
        //private void Initialize( string title )
        //{
        //    Title = title;
        //}

        //Mixed accessibility - one accessor may be more restrictive
        //public int Id { get; private set; }
        public int Id { get; set; } // private ;

        [RequiredAttribute(AllowEmptyStrings = false)]
        [StringLength(255)]
        public string Title
        {
            ////null coalescing ::= E ?? E   (returns first non-null expression)
            ////null conditional ::= E?.M    (returns M?) changes the type of the expression

            ////Read: T get_Title ()
            //get 
            //{
            //    return _title ?? "";

            //    //return (_title != null) ? _title : "";
            //    //if (_title == null)
            //    //    return "";

            //    //return _title; 
            //}

            ////Write void set_Title ( string value )
            //set 
            //{
            //    // _title = value; 
            //    //_title = (value != null) ? value.Trim() : null;
            //    _title = value?.Trim();

            //    //Movie m;
            //    //int id = m?.Id ?? 0; // int?
            //}

            //Expression body for single line accessors
            get => _title ?? "";
            set => _title = value?.Trim();
        }

        /// <summary> Gets for sets the description </summary>
        public string Description
        {
            //get { return (_description != null) ? _description : ""; }
            //set { _description = (value != null ? value.Trim() : null); }

            get => (_description != null) ? _description : "";
            set => _description = (value != null ? value.Trim() : null);
        }

        /// <summary> Gets or sets the rating 
        [Required(AllowEmptyStrings = false)]
        [StringLength(20)]
        public string Rating
        {
            get { return (_rating != null) ? _rating : ""; }
            set { _rating = (value != null ? value.Trim() : null); }
        }

        //Full property syntax
        //public int RunLength
        //{
        //    get { return _runLength; }
        //    set { _runLength = value; }
        //}
        //Auto property
        [Range(0, 600, ErrorMessage = "Run Length cannot be longer than 10 hours")]
        [Display(Name = "Run Length")]
        public int RunLength { get; set; }

        //public double ReviewRating
        //{
        //    get { return _reviewRating; }
        //    set { _reviewRating = value; }
        //}
        public double ReviewRating { get; set; }

        //public int ReleaseYear
        //{
        //    get { return _releaseYear; }
        //    set { _releaseYear = value; }
        //}
        [Range(1900, 2100)]
        [Display(Name = "Release Year")]
        public int ReleaseYear { get; set; } = MinimumReleaseYear;

        public bool IsClassic { get; set; }
        
        // Fields
        // 1. Always camel cased, TODO: for now
        // 2. Should NEVER be public
        // 3. Always zero initialized or can default
        // 4. Cannot initialize to another field's value
        private string _title;
        private string _description;
        //private int _runLength;

        //TODO: Use the const Luke
        //private int _releaseYear = MinimumReleaseYear;

        //private double _reviewRating;
        private string _rating;
        //private bool _isClassic;

        // Field is constant and therefore cannot be changed without recompiling
        public const int MinimumReleaseYear = 1900;

        //public int GetAgeInYears ()
        //{
        //    return DateTime.Now.Year - ReleaseYear;
        //}

        public int AgeInYears
        {
            get { return DateTime.Now.Year - ReleaseYear; }
            //set { }
        }

        //public bool IsBlackAndWhite ()
        //{
        //    return ReleaseYear < 1922;
        //}

        //Expresson body for calculated property
        public bool IsBlackAndWhite => ReleaseYear < 1922;
        //{
        //    //get { return ReleaseYear < 1922; }
        //    get => ReleaseYear < 1922;
        //}

        // Methods - provide functionality (function inside a class)
        // Can reference fields in method
        // `this` represents the current instance, always the first parameter (implied)

        /// <summary> Copies movie </summary>
        /// <returns> A copy of the movie </returns>
        //public Movie Clone ()
        //{
        //    var movie = new Movie();
        //    movie.Id = Id;
        //    movie.Title = Title;
        //    movie.Description = Description;
        //    movie.RunLength = RunLength;
        //    movie.ReleaseYear = ReleaseYear;
        //    movie.ReviewRating = ReviewRating;
        //    movie.Rating = Rating;
        //    movie.IsClassic = IsClassic;

        //    return movie;
        //}


        public Movie Clone () => new Movie() {

            Id = Id,
            Title = Title,
            Description = Description,
            RunLength = RunLength,
            ReleaseYear = ReleaseYear,
            ReviewRating = ReviewRating,
            Rating = Rating,
            IsClassic = IsClassic,
        };

        public override string ToString () => $"{Title} ({ReleaseYear})";
        

        //public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        //{
        //    var errors = new List<ValidationResult>();

        //    ////Title is required
        //    //if (String.IsNullOrEmpty(Title)) //this.title
        //    //    //return "Title is required";
        //    //    errors.Add(new ValidationResult("Title is required", new[] { nameof(Title) }));

        //    ////Run length >= 0
        //    ////if (this.runLength < 0)
        //    //if (RunLength < 0)
        //    //    errors.Add(new ValidationResult( "Run Length must be at least zero", new[] { nameof(RunLength) }));

        //    ////Release year >= 1900
        //    //if (ReleaseYear < MinimumReleaseYear)
        //    //    errors.Add(new ValidationResult("Release Year must be at least " + MinimumReleaseYear, new[] { nameof(ReleaseYear) }));

        //    ////Rating is required
        //    //if (String.IsNullOrEmpty(Rating))
        //    //    errors.Add(new ValidationResult("Rating is required", new[] { nameof(Rating) }));

        //    return errors;
        //}

        private void SetDiscriptionToTitle ()
        {
            Description = Title;
        }

    }
}
