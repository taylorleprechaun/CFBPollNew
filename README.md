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

### Rankings (Updated 12/5/2021)

**Post CCG Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Alabama | 1.0000 | 12-1
2 | Georgia | 0.9962 | 12-1
3 | Michigan | 0.9767 | 12-1
4 | Cincinnati | 0.9716 | 13-0
5 | Baylor | 0.9495 | 11-2
6 | Oklahoma State | 0.9472 | 11-2
7 | Notre Dame | 0.9336 | 11-1
8 | Ohio State | 0.9310 | 10-2
9 | Mississippi | 0.9306 | 10-2
10 | Michigan State | 0.9186 | 10-2
11 | Pittsburgh | 0.9053 | 11-2
12 | Oklahoma | 0.9030 | 10-2
13 | Brigham Young | 0.8900 | 10-2
14 | Utah | 0.8893 | 10-3
15 | Wake Forest | 0.8853 | 10-3
16 | UTSA | 0.8852 | 12-1
17 | Louisiana-Lafayette | 0.8837 | 12-1
18 | San Diego State | 0.8793 | 11-2
19 | Oregon | 0.8745 | 10-3
20 | Clemson | 0.8740 | 9-3
21 | Iowa | 0.8663 | 10-3
22 | Arkansas | 0.8596 | 8-4
23 | North Carolina State | 0.8553 | 9-3
24 | Houston | 0.8536 | 11-2
25 | Wisconsin | 0.8521 | 8-4

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/master/PreviousPolls/2021-Week%2015%20Post%20CCG.md)

#### Observations and Notes (Updated 12/5/2021)

* My poll is picking the playoff as Alabama, Georgia, Michigan, and Cincinnati.  There's a pretty large drop in rating from Cincinnati to Baylor/Oklahoma State.
* Last week I used my computer to predict the top 6 after putting in the poll's predicted scores into the matchups (and swapping them around).  The real-life result was Michigan-Baylor-Alabama-Cincinnati and the real life result checked against the 16 scenarios results in the same predicted top 6.  So yeah I'm pretty cracked.

#### Predictions (Updated 12/5/2021)

The way my system predicts is still a work in progress.  I plan to make bowl predictions when all those games are decided but for now we'll wait until those are announced.

As for last week, let's see how we did:

Away - Home | Predicted Score | Actual Score | Pick | Spread | ATS Pick | O/U | O/U Pick
---|---|---|---|---|---|---|---
Western Kentucky - UTSA | 37 - 39 | 41 - 49 | UTSA ✔ | Western Kentucky -3 | UTSA ✔ | 74.5 | Over ✔
Oregon - Utah | 28 - 32 | 10 - 38 | Utah ✔ | Utah -3 | Utah ✔ | 57.5 | Over ❌
Baylor - Oklahoma State | 21 - 23 | 21 - 16 | Oklahoma State ❌ | Oklahoma State -7 | Baylor ✔ | 45 | Under ✔
Kent State - Northern Illinois | 38 - 41 | 23 - 41 | Northern Illinois ✔ | Kent State -3.5 | Northern Illinois ✔ | 75.5 | Over ❌
Utah State - San Diego State | 23 - 31 | 46 - 13 | San Diego State ❌ | San Diego State -6.5 | San Diego State ❌ | 49.5 | Over ✔
Appalachian State - Louisiana | 28 - 25 | 16 - 24 | Appalachian State ❌ | Appalachian State -2.5 | Appalachian State ❌ | 52 | Over ❌
Georgia - Alabama | 32 - 23 | 24 - 41 | Georgia ❌ | Georgia -6 | Georgia ❌ | 49 | Over ✔
Houston - Cincinnati | 25 - 35 | 20 - 35 | Cincinnati ✔ | Cincinnati -10.5 | Houston ❌ | 52.5 | Over ✔
Michigan - Iowa | 29 - 17 | 42 - 3 | Michigan ✔ | Michigan -12 | Push ➖ | 44 | Over ✔
Pittsburgh - Wake Forest | 42 - 38 | 45 - 21 | Pittsburgh ✔ | Pittsburgh -3.5 | Pittsburgh ✔ | 72.5 | Over ❌

* 6-4 on outright picks
* 5-4 against the spread
* 6-4 on the O/U

This puts the overall total to:

* 41-16 on outright picks
* 26-25 against the spread
* 23-30 on the O/U

Wrapping up the 2021 (regular) season:

In the few weeks this has been running it's been doing alright.  There are some improvements I have in mind for this that I plan to implement and "test" over the offseason.  For the current season I've predicted 57 games (picking games from the current week that look interesting to me).

In those 57 games the algorithm has gone 41-16 (.719) on outright picks, 26-25 against the spread (.510), and 23-30 (.434) on the over/under.  I'm pretty happy with the outright picks but there's tweaks I want to make which I think will improve it and as a result improve the ATS result.  The over/under, however, is a different story.

I noticed a couple weeks ago my algorithm picks the Over a lot... like way too much.  In 57 games it picked Over on about 68% of them.  The actual outcome of the games was Over on about 44% of them.  My initial thoughts on this were two things: 1) I have ideas to improve the algorithm so maybe that will fix the issue and 2) I think my home field advantage system is shifting the combined scores too high.  I just do a blanket HomeTeam+3 thing in the prediction since generally speaking home field advantage is about 3 points.  If I take all my predictions and remove 3 points from the total, it shifts to picking over about 39% of the time but only a marginal increase in results (43% -> 48%).  As I update my prediction algorithm I need to keep this in mind.

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
