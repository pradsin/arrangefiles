# arrangefiles
arrangefiles moves files in a folder into sub folders derived from created date

Usage: arrange [OPTIONS]+ message
Greet a list of individuals with an optional message.
If no message is specified, a generic greeting is used.

Options:
  -d, --directory=DIRECTORY  the DIRECTORY to arrange files.
 
  -a, --arrange=VALUE        Arrange By could be any of the following
                               y-> Year, no leading zero (e.g. 2015 would be
                               15)
                               yy-> Year, leading zero (e.g. 2015 would be
                               015)
                               yyy-> Year, (e.g. 2015)
                               yyyy-> Year, (e.g. 2015)
                               M-> Month number(eg.3)
                               MM-> Month number with leading zero(eg.04)
                               MMM-> Abbreviated Month Name (e.g. Dec)
                               MMMM-> Full month name (e.g. December)
                               d -> Represents the day of the month as a number
                               from 1 through 31.
                               dd -> Represents the day of the month as a
                               number from 01 through 31.
                               ddd-> Represents the abbreviated name of the day
                               (Mon, Tues, Wed, etc).
                               dddd-> Represents the full name of the day
                               (Monday, Tuesday, etc).
                               h-> 12-hour clock hour (e.g. 4).
                               hh-> 12-hour clock, with a leading 0 (e.g. 06)
                               H-> 24-hour clock hour (e.g. 15)
                               HH-> 24-hour clock hour, with a leading 0 (e.g.
                               22)
                               m-> Minutes
                               mm-> Minutes with a leading zero
                               s-> Seconds
                               ss-> Seconds with leading zero
  -h, --help                 show this message and exit
