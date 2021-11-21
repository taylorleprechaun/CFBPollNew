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

### Rankings (Updated 11/21/2021)

**Week 13 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Georgia | 1.0000 | 11-0
2 | Alabama | 0.9312 | 10-1
3 | Oklahoma State | 0.9236 | 10-1
4 | Ohio State | 0.9236 | 10-1
5 | Cincinnati | 0.9206 | 11-0
6 | Michigan | 0.9199 | 10-1
7 | Notre Dame | 0.9110 | 10-1
8 | Oklahoma | 0.8960 | 10-1
9 | Mississippi | 0.8912 | 9-2
10 | Baylor | 0.8903 | 9-2
11 | Wake Forest | 0.8795 | 9-2
12 | UTSA | 0.8776 | 11-0
13 | Michigan State | 0.8759 | 9-2
14 | Wisconsin | 0.8592 | 8-3
15 | Brigham Young | 0.8553 | 9-2
16 | Oregon | 0.8551 | 9-2
17 | Iowa | 0.8551 | 9-2
18 | San Diego State | 0.8536 | 10-1
19 | Texas A&M | 0.8504 | 8-3
20 | Houston | 0.8483 | 10-1
21 | Pittsburgh | 0.8444 | 9-2
22 | Clemson | 0.8385 | 8-3
23 | Utah | 0.8376 | 8-3
24 | Appalachian State | 0.8365 | 9-2
25 | Louisiana-Lafayette | 0.8339 | 10-1

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/master/PreviousPolls/2021-Week%2013.md)

#### Observations and Notes (Updated 11/21/2021)

* Nothing special of note this week.  Fire Dan Mullen into the sun.

#### Predictions (Updated 11/21/2021)

Some predictions from my system for Week 13.  The way it predicts is still a work in progress but let's see anyway how the current algorithm performs

Away - Home | Predicted Score | Actual Score | Pick | Spread | ATS Pick | O/U | O/U Pick
---|---|---|---|---|---|---|---
Ole Miss - Mississippi State | 33 - 32 |  | Ole Miss |  |  |  | 
Iowa - Nebraska | 20 - 24 |  | Nebraska |  |  |  | 
Kansas State - Texas | 31 - 33 |  | Texas |  |  |  | 
Alabama - Auburn | 38 - 27 |  | Alabama |  |  |  | 
Wisconsin - Minnesota | 23 - 19 |  | Wisconsin |  |  |  | 
Ohio State - Michigan | 38 - 33 |  | Ohio State |  |  |  | 
Oregon State - Oregon | 30 - 35 |  | Oregon |  |  |  | 
Penn State - Michigan State | 25 - 24 |  | Penn State |  |  |  | 
Texas A&M - LSU | 26 - 18 |  | Texas A&M |  |  |  | 
Clemson - South Carolina | 23 - 16 |  | Clemson |  |  |  | 
Oklahoma - Oklahoma State | 25 - 30 |  | Oklahoma State |  |  |  | 
Florida State - Florida | 27 - 34 |  | Florida |  |  |  | 

As for last week, let's see how we did:

Away - Home | Predicted Score | Actual Score | Pick | Spread | ATS Pick | O/U | O/U Pick
---|---|---|---|---|---|---|---
Illinois - Iowa | 9 - 23 | 23 - 33 | Iowa ✔ | Iowa -12 | Iowa ❌ | 38.5 | Under ❌
Arkansas - Alabama | 22 - 41 | 35 - 42 | Alabama ✔ | Alabama -20.5 | Arkansas ✔ | 58.5 | Over ✔
Oregon - Utah | 32 - 35 | 7 - 38 | Utah ✔ | Utah -3 | Push ➖ | 58.5 | Over ❌
SMU - Cincinnati | 30 - 39 | 14 - 48 | Cincinnati ✔ | Cincinnati -9.5 | SMU ❌ | 65.5 | Over ❌
Iowa State - Oklahoma | 29 - 34 | 21 - 28 | Oklahoma ✔ | Oklahoma -3 | Iowa State ✔ | 59 | Over ❌
Oklahoma State - Texas Tech | 36 - 24 | 23 - 0 | Oklahoma State ✔ | Oklahoma State -10 | Oklahoma State ✔ | 55 | Over ❌
Michigan State - Ohio State | 29 - 45 | 7 - 56 | Ohio State ✔ | Ohio State -19.5 | Michigan State ❌ | 70 | Over ❌
Wake Forest - Clemson | 31 - 29 | 27 - 48 | Wake Forest ❌ | Clemson -3.5 | Wake Forest ❌ | 57 | Over ✔
Nebraska - Wisconsin | 18 - 25 | 28 - 35 | Wisconsin ✔ | Wisconsin -10 | Nebraska ✔ | 43.5 | Under ❌
Auburn - South Carolina | 29 - 22 | 17 - 21 | Auburn ❌ | Auburn -7 | Push ➖ | 45 | Over ❌
Baylor - Kansas State | 27 - 23 | 20 - 10 | Baylor ✔ | Kansas State -2.5 | Baylor ✔ | 50 | Push ➖

* 9-2 on outright picks
* 5-4 against the spread
* 2-8 on the O/U (ouch)

This puts the overall total to:

* 28-7 on outright picks
* 16-15 against the spread
* 12-20 on the O/U


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
