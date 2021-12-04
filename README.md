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
* 12/4/2021: Automated generating weekly predictions

### Rankings (Updated 11/28/2021)

**Week 14 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Georgia | 1.0000 | 12-0
2 | Alabama | 0.9534 | 11-1
3 | Oklahoma State | 0.9489 | 11-1
4 | Michigan | 0.9388 | 11-1
5 | Cincinnati | 0.9334 | 12-0
6 | Notre Dame | 0.9110 | 11-1
7 | Ohio State | 0.9085 | 10-2
8 | Baylor | 0.9071 | 10-2
9 | Mississippi | 0.9058 | 10-2
10 | Michigan State | 0.8958 | 10-2
11 | Wake Forest | 0.8902 | 10-2
12 | San Diego State | 0.8849 | 11-1
13 | Oklahoma | 0.8805 | 10-2
14 | Oregon | 0.8748 | 10-2
15 | Iowa | 0.8656 | 10-2
16 | Brigham Young | 0.8648 | 10-2
17 | Pittsburgh | 0.8602 | 10-2
18 | Clemson | 0.8542 | 9-3
19 | UTSA | 0.8522 | 11-1
20 | Utah | 0.8515 | 9-3
21 | Houston | 0.8471 | 11-1
22 | Louisiana-Lafayette | 0.8432 | 11-1
23 | Appalachian State | 0.8398 | 10-2
24 | Arkansas | 0.8383 | 8-4
25 | North Carolina State | 0.8365 | 9-3

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/master/PreviousPolls/2021-Week%2014%20Pre%20CCG.md)

#### Observations and Notes (Updated 11/28/2021)

* I put in some dummy scores using my predicted scores (see below) and based on those predictions my system is predicting Georgia, Oklahoma State, Michigan, and Cincinnati as the top 4
* I also messed around with the combinations of wins/losses for each team.  The way I messed with the combinations was really basic (just flip the predicted scores around) and depending on the actual outcomes of the games the results could be a little off.  I also found that the ACC championship and Pac-12 championship didn't change the results of the top 4 so I didn't include those combinations.  For the full output refer to: [combinations](https://github.com/taylorleprechaun/CFBPollNew/blob/master/PreviousPolls/2021-Week%2014%20Scenarios.xlsx)

Team | In | Out | Notes
---|---|---|---
Georgia | 16 | 0 | Always in
Alabama | 15 | 1 | 1 - Lose + Michigan, Oklahoma State, Cincinnati win
Oklahoma State | 10 | 6 | 6 - Lose + Iowa, Houston win
Michigan | 10 | 6 | 6 - Lose + Georgia, Houston win
Cincinnati | 7 | 9 | 8 - Lose.  1 - Win + Michigan, Oklahoma State, Alabama win
Baylor | 6 | 10 | 8 - Lose.  2 - Win + Michigan, Cincinnati win
Notre Dame | 0 | 16 | Peaks at #5


#### Predictions (Updated 11/28/2021)

Some predictions from my system for Week 14.  The way it predicts is still a work in progress but let's see anyway how the current algorithm performs

Away - Home | Predicted Score | Actual Score | Pick | Spread | ATS Pick | O/U | O/U Pick
---|---|---|---|---|---|---|---
Western Kentucky - UTSA | 37 - 39 |  | UTSA |  |  |  | 
Oregon - Utah | 28 - 32 |  | Utah |  |  |  | 
Baylor - Oklahoma State | 21 - 23 |  | Oklahoma State |  |  |  | 
Kent State - Northern Illinois | 38 - 41 |  | Northern Illinois |  |  |  | 
Utah State - San Diego State | 23 - 31 |  | San Diego State |  |  |  | 
Appalachian State - Louisiana | 28 - 25 |  | Appalachian State |  |  |  | 
Georgia - Alabama | 32 - 23 |  | Georgia |  |  |  | 
Houston - Cincinnati | 25 - 35 |  | Cincinnati |  |  |  | 
Michigan - Iowa | 29 - 17 |  | Michigan |  |  |  | 
Pittsburgh - Wake Forest | 42 - 38 |  | Pittsburgh |  |  |  | 
 
As for last week, let's see how we did:

Away - Home | Predicted Score | Actual Score | Pick | Spread | ATS Pick | O/U | O/U Pick
---|---|---|---|---|---|---|---
Ole Miss - Mississippi State | 33 - 32 | 31 - 21 | Ole Miss ✔ | Mississippi State -2 | Ole Miss ✔ | 65 | Push ➖
Iowa - Nebraska | 20 - 24 | 28 - 21 | Nebraska ❌ | Nebraska -1.5 | Nebraska ❌ | 41 | Over ✔
Kansas State - Texas | 31 - 33 | 17 - 22 | Texas ✔ | Texas -3 | Kansas State ❌ | 54.5 |  Over ❌
Alabama - Auburn | 38 - 27 | 24 - 22 | Alabama ✔ | Alabama -20.5 | Auburn ✔ | 57 | Over ❌
Wisconsin - Minnesota | 23 - 19 | 13 - 23 | Wisconsin ❌ | Wisconsin -7 | Minnesota ✔ | 39 | Over ❌
Ohio State - Michigan | 38 - 33 | 27 - 42 | Ohio State ❌ | Ohio State -6.5 | Michigan ✔ | 64.5 | Over ✔
Oregon State - Oregon | 30 - 35 | 29 - 38 | Oregon ✔ | Oregon -7.5 | Oregon State ❌ | 61 | Over ✔
Penn State - Michigan State | 25 - 24 | 27 - 30 | Penn State ❌ | Penn State -4.5 | Michigan State ✔ | 51.5 | Under ❌
Texas A&M - LSU | 26 - 18 | 24 - 27 | Texas A&M ❌ | Texas A&M -6 | Texas A&M ❌ | 46.5 | Under ❌
Clemson - South Carolina | 23 - 16 | 30 - 0 | Clemson ✔ | Clemson -11.5 | South Carolina ❌ | 42.5 | Under ✔
Oklahoma - Oklahoma State | 25 - 30 | 33 - 37 | Oklahoma State ✔ | Oklahoma State -4 | Push ➖ | 50 | Over ✔
Florida State - Florida | 27 - 34 | 21 - 24 | Florida ✔ | Florida -4 | Florida ❌ | 58.5 | Over ❌

* 7-5 on outright picks
* 5-6 against the spread
* 5-6 on the O/U

This puts the overall total to:

* 35-12 on outright picks
* 21-21 against the spread
* 17-26 on the O/U


### TODO List (Updated 10/24/2021)

1. Automate results of weekly predictions

2. Tweak/improve/adjust prediction algorithm to a point where I'm happy with it.  I have some ideas for tweaks but for this season it's good enough.

3. More print-outs: conference average rating, conference top to bottom rating+ranking, conference ranking, division ranking, etc.

4. Add a UI.  This is currently a command line project.  I want to add a UI with dropdowns for the season and sections for outputs and stuff.
	
5. Add improvements for early season ratings (recruiting info, returning production stats, etc. (not sure where to get this data though))

6. ????

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
