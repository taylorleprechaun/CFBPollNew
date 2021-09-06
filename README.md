# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  I want to get this added to the Massey Composite for the ~~2020~~ 2021 season and beyond.  

### Recent changes

* 9/6/2021: Initial commit of re-write of original poll
	* Re-written to be better
	* Nearly identical ratings as old version (the ten-thousandths place is where the decimals start changing)
	* Way to weight previous vs. current season during the early weeks to help avoid (but doesn't totally eliminate) weird ratings

### Rankings (Updated 9/6/2021)

**Week 1 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | USC | 1.0000 | 1-0
2 | Alabama | 0.9966 | 1-0
3 | Ohio State | 0.9670 | 1-0
4 | San Jose State | 0.9633 | 1-1
5 | Cincinnati | 0.9298 | 1-0
6 | Brigham Young | 0.9225 | 1-0
7 | Texas A&M | 0.9198 | 1-0
8 | Oklahoma | 0.9168 | 1-0
9 | Georgia | 0.9024 | 1-0
10 | Notre Dame | 0.9000 | 1-0
11 | Texas | 0.8857 | 1-0
12 | UTSA | 0.8754 | 1-0
13 | Oregon | 0.8657 | 1-0
14 | Army | 0.8638 | 1-0
15 | Iowa | 0.8619 | 1-0
16 | Florida | 0.8590 | 1-0
17 | UCLA | 0.8544 | 2-0
18 | Nevada | 0.8452 | 1-0
19 | Appalachian State | 0.8446 | 1-0
20 | North Carolina State | 0.8435 | 1-0
21 | Marshall | 0.8365 | 1-0
22 | Auburn | 0.8336 | 1-0
23 | Hawaii | 0.8198 | 1-1
24 | Pittsburgh | 0.8172 | 1-0
25 | Central Florida | 0.8157 | 1-0

#### Observations and Notes (Updated 9/6/2021)

* My method to improve early season ratings does work but there are still some flaws with it.  The biggest example that can be pointed out is San Jose State at #4 because of how high they finished the previous season.  This will likely smooth out over the next couple weeks (as my poll usually does, I just avoided publishing it until the real weird stuff was gone in the past)
* Yes, I know there is one more game tonight.  I don't care.

### TODO List (Updated 9/26/2020)

1. More print-outs: conference average rating, conference top to bottom rating+ranking, conference ranking, division ranking, etc.

2. Add a UI.  This is currently a command line project.  I want to add a UI with dropdowns for the season and sections for outputs and stuff.
	
3. Add improvements for early season ratings (recruiting info, returning production stats, etc. (not sure where to get this data though))

4. ????

### Misc.

**The Best and Worst of all Time!**

My poll, as of this update, has been run across every season from 2000 through 2019 (that's because sports-reference only goes back to the year 2000) (using my new rating formula, meaning the ratings from all previous posts aren't totally accurate to what you'll see here, but the formula is way better now, trust me)

Something I noticed across these seasons is that the best teams had a rating above 40 and the worst teams were below 16, so I made a list of them (here: https://github.com/taylorleprechaun/CFBPoll/blob/master/rsc/teams/BOAT%20and%20WOAT.xlsx )

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