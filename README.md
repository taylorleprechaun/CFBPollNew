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

### Rankings (Updated 10/31/2021)

**Week 10 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Georgia | 1.0000 | 8-0
2 | Michigan State | 0.9620 | 8-0
3 | Wake Forest | 0.9483 | 8-0
4 | Michigan | 0.9350 | 7-1
5 | Oklahoma | 0.9313 | 9-0
6 | Cincinnati | 0.9301 | 8-0
7 | Alabama | 0.9202 | 7-1
8 | Baylor | 0.9156 | 7-1
9 | Oklahoma State | 0.9120 | 7-1
10 | Ohio State | 0.9113 | 7-1
11 | Notre Dame | 0.9003 | 7-1
12 | Auburn | 0.8710 | 6-2
13 | Mississippi | 0.8671 | 6-2
14 | Oregon | 0.8668 | 7-1
15 | Kentucky | 0.8575 | 6-2
16 | UTSA | 0.8535 | 8-0
17 | San Diego State | 0.8506 | 7-1
18 | Houston | 0.8434 | 7-1
19 | Iowa | 0.8390 | 6-2
20 | Brigham Young | 0.8372 | 7-2
21 | Air Force | 0.8318 | 6-2
22 | Appalachian State | 0.8313 | 6-2
23 | Texas A&M | 0.8300 | 6-2
24 | Wisconsin | 0.8203 | 5-3
25 | Arkansas | 0.8169 | 5-3

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/master/PreviousPolls/2021-Week%2010.md)

#### Observations and Notes (Updated 10/24/2021)

* Nothing special of note this week.  Still fire Todd Grantham.

#### Predictions (Updated 10/31/2021)

Some predictions from my system for Week 10.  The way it predicts is still a work in progress but let's see anyway how the current algorithm performs

Away - Home | Predicted Score | Actual Score | Pick | Spread | ATS Pick | O/U | O/U Pick
---|---|---|---|---|---|---|---
Auburn - Texas A&M | 24 - 25 (24.1 - 24.7)❗ |  | Texas A&M |  |  |  |  |
Texas - Iowa State | 33 - 36 |  | Iowa State |  |  |  |  |
Wake Forest - North Carolina | 44 - 35 |  | Wake Forest |  |  |  |  |
Michigan State - Purdue | 26 - 20 |  | Michigan State |  |  |  |  |
Penn State - Maryland | 31 - 24 |  | Penn State |  |  |  |  |
Tennessee - Kentucky | 30 - 27 |  | Tennessee |  |  |  |  |
Oregon - Washington | 28 - 21 |  | Oregon |  |  |  |  |
Oklahoma State - West Virginia | 23 - 24 (22.9 - 23.5)❗ |  | West Virginia |  |  |  |  |
Liberty - Ole Miss | 34 - 34 (33.88-33.91)❗❗❗ |  | Ole Miss |  |  |  |  |

Some of these margins are pretty crazy.  I'm torn on if I want to update this section mid-week with my predictions or just do it next week using closing odds when I update this like I did this week.  No one is using this to make bets (and I strongly advise against it if you are thinking about it) but betting information can be inferred just by looking at the predicted scores so there's no real advantage to updating it mid-week.  Leaning towards just updating it every Sunday when I update my poll.

As for last week, let's see how we did:

Away - Home | Predicted Score | Actual Score | Pick | Spread | ATS Pick | O/U | O/U Pick
---|---|---|---|---|---|---|---
Georgia - Florida  | 33 - 15 | 34 - 7 | Georgia ✔ | Georgia -14 | Georgia ✔ | 51 | Under ✔
Michigan - Michigan State | 31 - 25 | 33 - 37 | Michigan ❌ | Michigan -4 | Michigan ❌ | 51 | Over ✔
Texas - Baylor  | 34 - 41 | 24 - 31 | Baylor ✔ | Baylor -2 | Baylor ✔ | 61 | Over ❌
Ole Miss - Auburn | 33 - 37 | 20 - 31 | Auburn ✔ | Auburn -3 | Auburn ✔ | 68 | Over ❌
Penn State - Ohio State | 21 - 42 | 24 - 33 | Ohio State ✔ | Ohio State -18.5 | Ohio State ❌ | 61 | Over ❌
SMU - Houston | 30 - 32 | 37 - 44 | Houston ✔ | SMU -1 | Houston ✔ | 62 | Push ➖

* 5-1 on outright picks
* 4-2 against the spread
* 2-3 on the O/U

Not bad

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
