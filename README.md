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

### Rankings (Updated 11/14/2021)

**Week 12 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Georgia | 1.0000 | 10-0
2 | Michigan | 0.9278 | 9-1
3 | Oklahoma State | 0.9191 | 9-1
4 | Notre Dame | 0.9149 | 9-1
5 | Wake Forest | 0.9117 | 9-1
6 | Michigan State | 0.9104 | 9-1
7 | Ohio State | 0.9097 | 9-1
8 | Alabama | 0.9086 | 9-1
9 | Cincinnati | 0.9064 | 10-0
10 | Mississippi | 0.9000 | 8-2
11 | Oklahoma | 0.8905 | 9-1
12 | Oregon | 0.8852 | 9-1
13 | Baylor | 0.8796 | 8-2
14 | UTSA | 0.8716 | 10-0
15 | Brigham Young | 0.8657 | 8-2
16 | San Diego State | 0.8617 | 9-1
17 | Wisconsin | 0.8595 | 7-3
18 | Iowa | 0.8542 | 8-2
19 | Houston | 0.8457 | 9-1
20 | Arkansas | 0.8375 | 7-3
21 | Pittsburgh | 0.8299 | 8-2
22 | Appalachian State | 0.8298 | 8-2
23 | Texas A&M | 0.8284 | 7-3
24 | Louisiana-Lafayette | 0.8255 | 9-1
25 | Kansas State | 0.8210 | 7-3

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/master/PreviousPolls/2021-Week%2012.md)

#### Observations and Notes (Updated 11/14/2021)

* Nothing special of note this week.  Fire Dan Mullen.

#### Predictions (Updated 11/14/2021)

Some predictions from my system for Week 12.  The way it predicts is still a work in progress but let's see anyway how the current algorithm performs

Away - Home | Predicted Score | Actual Score | Pick | Spread | ATS Pick | O/U | O/U Pick
---|---|---|---|---|---|---|---
Illinois - Iowa | 9 - 23 |  | Iowa |  |  |  | 
Arkansas - Alabama | 22 - 41 |  | Alabama |  |  |  | 
Oregon - Utah | 32 - 35 |  | Utah |  |  |  | 
SMU - Cincinnati | 30 - 39 |  | Cincinnati |  |  |  | 
Iowa State - Oklahoma | 29 - 34 |  | Oklahoma |  |  |  | 
Oklahoma State - Texas Tech | 36 - 24 |  | Oklahoma State |  |  |  | 
Michigan State - Ohio State | 29 - 45 |  | Ohio State |  |  |  | 
Wake Forest - Clemson | 31 - 29 |  | Wake Forest |  |  |  | 
Nebraska - Wisconsin | 18 - 25 |  | Wisconsin |  |  |  | 
Auburn - South Carolina | 29 - 22 |  | Auburn |  |  |  | 
Baylor - Kansas State | 27 - 23 |  | Baylor |  |  |  | 

As for last week, let's see how we did:

Away - Home | Predicted Score | Actual Score | Pick | Spread | ATS Pick | O/U | O/U Pick
---|---|---|---|---|---|---|---
Minnesota - Iowa | 17 - 21 | 22 - 27 | Iowa ✔ | Iowa -4 | Push ➖ | 37 | Over ✔
Georgia - Tennessee | 38 - 21 | 41 - 17 | Georgia ✔ | Georgia -19.5 | Tennessee ❌ | 56 |  Over ✔
Oklahoma - Baylor | 34 - 35 | 14 - 27 | Baylor ✔ | Oklahoma -4 | Baylor ✔ | 63 | Over ❌
Michigan - Penn State | 28 - 21 | 21 - 17 | Michigan ✔ | Michigan -2.5 | Michigan ✔ | 48 | Over ❌
Mississippi State - Auburn | 21 - 33 | 43 - 34 | Auburn ❌ | Auburn -5.5 | Auburn ❌ | 51 | Over ✔
Purdue - Ohio State | 20 - 40 | 31 - 59 | Ohio State ✔ | Ohio State -19 | Ohio State ✔ | 65 | Under ❌
Texas A&M - Ole Miss | 26 - 28 | 19 - 29 | Ole Miss ✔ | Texas A&M -1.5 | Ole Miss ✔ | 58 | Under ✔
NC State - Wake Forest | 30 - 35 | 42 - 45 | Wake Forest ✔ | Wake Forst -1 | Wake Forest ✔ | 65 | Push ➖
Nevada - San Diego State | 27 - 29 | 21 - 23 | San Diego State ✔ | San Diego State -2.5 | Nevada ✔ | 45 | Over ❌

* 8-1 on outright picks
* 6-2 against the spread
* 4-4 on the O/U

This puts the overall total to:

* 19-5 on outright picks
* 11-11 against the spread
* 10-12 on the O/U


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
