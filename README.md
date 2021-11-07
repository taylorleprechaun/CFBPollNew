# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  ~~I want to get this added to the Massey Composite for the ~~2020~~ 2021 season and beyond.~~  Part of the Massey Composite (Steinberg/TSS) !!!!!!!!!!!

### Recent changes

* 9/6/2021: Initial commit of re-write of original poll
	* Re-written to be better
	* Nearly identical ratings as old version (the ten-thousandths place is where the decimals start changing)
	* Way to weight previous vs. current season during the early weeks to help avoid (but doesn't totally eliminate) weird ratings
* 9/12/2021: Changed how stuff gets outputted to help me do the poll-running process better
* 10/17/2021: Added a very basic prediction algorithm (though that may be too fancy a word for it actually is) and rewrote some of the program to support selecting a "mode" to run the program in (Poll mode or Predictor mode).  Just like the Rating class, the Predictor class is also excluded from the project

### Rankings (Updated 11/7/2021)

**Week 11 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Georgia | 1.0000 | 9-0
2 | Oklahoma | 0.9337 | 9-0
3 | Alabama | 0.9330 | 8-1
4 | Oklahoma State | 0.9203 | 8-1
5 | Cincinnati | 0.9196 | 9-0
6 | Michigan | 0.9177 | 8-1
7 | Michigan State | 0.9123 | 8-1
8 | Ohio State | 0.9043 | 8-1
9 | Notre Dame | 0.9028 | 8-1
10 | Wake Forest | 0.8948 | 8-1
11 | Mississippi | 0.8901 | 7-2
12 | UTSA | 0.8862 | 9-0
13 | Oregon | 0.8788 | 8-1
14 | Texas A&M | 0.8706 | 7-2
15 | Baylor | 0.8654 | 7-2
16 | Brigham Young | 0.8649 | 8-2
17 | Wisconsin | 0.8614 | 6-3
18 | Iowa | 0.8609 | 7-2
19 | San Diego State | 0.8499 | 8-1
20 | Auburn | 0.8423 | 6-3
21 | Houston | 0.8400 | 8-1
22 | Arkansas | 0.8360 | 6-3
23 | Penn State | 0.8341 | 6-3
24 | Appalachian State | 0.8308 | 7-2
25 | North Carolina State | 0.8263 | 7-2

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/master/PreviousPolls/2021-Week%2011.md)

#### Observations and Notes (Updated 11/7/2021)

* Nothing special of note this week.  Fire Dan Mullen.

#### Predictions (Updated 11/7/2021)

Some predictions from my system for Week 11.  The way it predicts is still a work in progress but let's see anyway how the current algorithm performs

Away - Home | Predicted Score | Actual Score | Pick | Spread | ATS Pick | O/U | O/U Pick
---|---|---|---|---|---|---|---
Minnesota - Iowa | 17 - 21 |  | Iowa |  |  |  | 
Georgia - Tennessee | 38 - 21 |  | Georgia |  |  |  | 
Oklahoma - Baylor | 34 - 35 |  | Baylor |  |  |  | 
Michigan - Penn State | 28 - 21 |  | Michigan |  |  |  | 
Mississippi State - Auburn | 21 - 33 |  | Auburn |  |  |  | 
Purdue - Ohio State | 20 - 40 |  | Ohio State |  |  |  | 
Texas A&M - Ole Miss | 26 - 28 |  | Ole Miss |  |  |  | 
NC State - Wake Forest | 30 - 35 |  | Wake Forest |  |  |  | 
Nevada - San Diego State | 27 - 29 |  | San Diego State |  |  |  | 
 
Decided against updating mid-week.  Like I said last week, anyone could just use the predicted margins and some mental math to make their bets (I strongly advise against this).

As for last week, let's see how we did:

Away - Home | Predicted Score | Actual Score | Pick | Spread | ATS Pick | O/U | O/U Pick
---|---|---|---|---|---|---|---
Auburn - Texas A&M | 24 - 25 (24.1 - 24.7)❗ | 3 - 20 | Texas A&M ✔ | Texas A&M -4.5 | Auburn ❌ | 50 | Under ✔
Texas - Iowa State | 33 - 36 | 7 - 30 | Iowa State ✔ | Iowa State -6 | Texas ❌ | 60 | Over ❌
Wake Forest - North Carolina | 44 - 35 | 55 - 58 | Wake Forest ❌ | UNC -2.5 | Wake Forest ❌ | 78 | Over ✔
Michigan State - Purdue | 26 - 20 | 29 - 40 | Michigan State ❌ | Michigan State -2.5 | Michigan State ❌ | 54 | Under ❌
Penn State - Maryland | 31 - 24 | 31 - 14 | Penn State ✔ | Penn State -10 | Maryland ❌ | 57 | Under ✔
Tennessee - Kentucky | 30 - 27 | 45 - 42 | Tennessee ✔ | Tennessee -1 | Tennessee ✔ | 58 | Under ❌
Oregon - Washington | 28 - 21 | 26 - 16 | Oregon ✔ | Oregon -7 | Push ➖ | 48 | Over ❌
Oklahoma State - West Virginia | 23 - 24 (22.9 - 23.5)❗ | 24 - 3 | West Virginia ❌ | Oklahoma State -2.5 | West Virginia ❌ | 49 | Under ✔
Liberty - Ole Miss | 34 - 34 (33.88-33.91)❗❗❗ | 14 - 27 | Ole Miss ✔ | Ole Miss -7.5 | Liberty ❌ | 67 | Over ❌

* 6-3 on outright picks
* 1-7 against the spread (ouch)
* 4-5 on the O/U

This puts the overall total to:

* 11-4 on outright picks
* 5-9 against the spread
* 6-8 on the O/U


### TODO List (Updated 10/24/2021)

1. Tweak/improve/adjust prediction algorithm to a point where I'm happy with it ~~and then start including some "picks of the week" type segment to this project~~.

2. More print-outs: conference average rating, conference top to bottom rating+ranking, conference ranking, division ranking, etc.

3. Add a UI.  This is currently a command line project.  I want to add a UI with dropdowns for the season and sections for outputs and stuff.
	
4. Add improvements for early season ratings (recruiting info, returning production stats, etc. (not sure where to get this data though))

5. ????

### Misc.

**The Best and Worst of all Time!**

My poll, as of this update, has been run across every season from 2000 through 2019 (that's because sports-reference only goes back to the year 2000) (using my new rating formula, meaning the ratings from all previous posts aren't totally accurate to what you'll see here, but the formula is way better now, trust me)

Something I noticed across these seasons is that the best teams had a rating above 40 and the worst teams were below 16, so I made a list of them (here: https://github.com/taylorleprechaun/CFBPollNew/blob/master/rsc/teams/BOAT%20and%20WOAT.xlsx )

I decided to split up the rankings between pre-CFP and CFP eras.  This was because the teams in the CFP would get little bumps from playing an extra game against an elite-level team.

*New additions for the 2020 season!*

* This year Alabama clocks in with a 40.866 in my poll, placing them at #6 in the Playoff Era
* Vanderbilt, Bowling Green, and FIU clock in with 15.040, 15.610, and 15.790, respectively.  This puts them all outside of the all-time bottom 5, but it puts Vanderbilt at #3 worst of the Playoff Era.

**The top 5 Best of all Time (pre-CFP era)**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2001 | Miami FL | 42.309 | 12-0
2 | 2009 | Alabama | 41.756 | 14-0
3 | 2010 | Auburn | 41.464 | 14-0
4 | 2005 | Texas | 41.291 | 13-0
5 | 2000 | Oklahoma | 41.246 | 13-0

**The top 5 Best of all Time (CFP era)**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2018 | Clemson | 42.445 | 15-0
2 | 2019 | LSU | 42.374 | 15-0
3 | 2015 | Alabama | 41.615 | 14-1
4 | 2016 | Alabama | 41.061 | 14-1
5 | 2016 | Clemson | 41.044 | 14-1

**The bottom 5 Worst of all Time**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2019 | Akron | 13.370 | 0-12
2 | 2009 | EMU | 13.809 | 0-12
3 | 2004 | UCF | 13.954 | 0-11
4 | 2013 | Miami OH | 13.973 | 0-12
5 | 2006 | FIU | 14.394 | 0-12
