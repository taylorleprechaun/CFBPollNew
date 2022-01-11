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

### Rankings (Updated 1/11/2022)

**Final 2021 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Georgia | 1.0000 | 14-1
2 | Alabama | 0.9619 | 13-2
3 | Oklahoma State | 0.9431 | 12-2
4 | Baylor | 0.9415 | 12-2
5 | Cincinnati | 0.9296 | 13-1
6 | Michigan | 0.9280 | 12-2
7 | Ohio State | 0.9204 | 11-2
8 | Michigan State | 0.9112 | 11-2
9 | Oklahoma | 0.9004 | 11-2
10 | Notre Dame | 0.8804 | 11-2
11 | San Diego State | 0.8781 | 12-2
12 | Mississippi | 0.8760 | 10-3
13 | Louisiana-Lafayette | 0.8674 | 13-1
14 | Clemson | 0.8634 | 10-3
15 | Wake Forest | 0.8580 | 11-3
16 | Pittsburgh | 0.8572 | 11-3
17 | UTSA | 0.8445 | 12-2
18 | Houston | 0.8434 | 12-2
19 | Arkansas | 0.8420 | 9-4
20 | Utah | 0.8353 | 10-4
21 | Kentucky | 0.8348 | 10-3
22 | Wisconsin | 0.8340 | 9-4
23 | Brigham Young | 0.8332 | 10-3
24 | North Carolina State | 0.8272 | 9-3
25 | Air Force | 0.8270 | 10-3

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/master/PreviousPolls/2021/2021-Week%2017%20Post%20NCG.md)

#### Observations and Notes (Updated 1/11/2022)

* RIP 1980 jokes 😢

#### Predictions (Updated 1/11/2022)

The way my system predicts is still a work in progress

Predictions this season: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/master/PreviousPolls/2021/Predictions/)

Overall (2021 + Bowls):

* 61-32 on outright picks
* 40-45 against the spread
* 42-46 on the O/U

### TODO List (Updated 10/24/2021)

1. Automate results of weekly predictions

2. Tweak/improve/adjust prediction algorithm to a point where I'm happy with it.  I have some ideas for tweaks but for this season it's good enough.

3. More print-outs: conference average rating, conference top to bottom rating+ranking, conference ranking, division ranking, etc.

4. Add a UI.  This is currently a command line project.  I want to add a UI with dropdowns for the season and sections for outputs and stuff.
	
5. Add improvements for early season ratings (recruiting info, returning production stats, etc. (not sure where to get this data though))

6. ????

### Misc.

**The Best and Worst of all Time!**

My poll, as of this update, has been run across every season from 2000 through 2021 (that's because sports-reference only goes back to the year 2000) (using my new rating formula, meaning the ratings from all previous posts aren't totally accurate to what you'll see here, but the formula is way better now, trust me)

Something I noticed across these seasons is that the best teams had a rating above 40 and the worst teams were below 16, so I made a list of them (here: https://github.com/taylorleprechaun/CFBPollNew/blob/master/rsc/teams/BOAT%20and%20WOAT.xlsx )

I decided to split up the rankings between pre-CFP and CFP eras.  This was because the teams in the CFP would get little bumps from playing an extra game against an elite-level team.

*New additions for the 2021 season!*

* This year Georgia clocks in with a 40.359 in my poll, placing them at #8 in the Playoff Era
* No teams had a rating less than 16.  So no new additions.  The worst team of the season was FIU with a rating of 16.036

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
