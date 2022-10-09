# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS) !!!!!!!!!!!

### Recent changes

* 9/6/2022: Updates to score prediction algorithm to smooth out early season data (the file that does this is excluded from the repo but I did make changes to it)
* 9/18/2022: Beginnings of code rewrite. I rewrote a lot of this when I couldn't sleep and so a lot of design decisions are poorly thought out and leave little flexibility for some improvements I want to make
    * Seasons/Team/Game data only exists for the season the poll is being run on but I want to be able to use more than just current season data in the rating/prediction algorithms in various circumstances (i.e. early season rating/predictions adjustments due to limited current season data points)
	* Cleaning up the above will allow me to rewrite parts of the rating/predictions algorithms a lot more cleanly since at the moment there's a lot of jank going on to get it working despite some of my design issues
* 9/25/2022: Some code re-organization and file path updates in preparation for bigger future changes

### Rankings (Updated 10/9/2022)

**Week 7 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Clemson | 1.0000 | 6-0
2 | Georgia | 0.9698 | 6-0
3 | Mississippi | 0.9689 | 6-0
4 | USC | 0.9461 | 6-0
5 | Tennessee | 0.9451 | 5-0
6 | Syracuse | 0.9424 | 5-0
7 | UCLA | 0.9417 | 6-0
8 | Alabama | 0.9403 | 6-0
9 | Texas Christian | 0.9368 | 5-0
10 | Ohio State | 0.9345 | 6-0
11 | Wake Forest | 0.9245 | 5-1
12 | Oklahoma State | 0.9171 | 5-0
13 | North Carolina State | 0.9103 | 5-1
14 | Oregon | 0.9074 | 5-1
15 | Penn State | 0.9071 | 5-0
16 | Michigan | 0.9058 | 6-0
17 | James Madison | 0.8946 | 5-0
18 | Kansas | 0.8946 | 5-1
19 | Kansas State | 0.8756 | 5-1
20 | Mississippi State | 0.8669 | 5-1
21 | Illinois | 0.8515 | 5-1
22 | Coastal Carolina | 0.8513 | 6-0
23 | Purdue | 0.8368 | 4-2
24 | Louisiana State | 0.8354 | 4-2
25 | San Jose State | 0.8283 | 4-1

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/master/CFBPoll/PreviousPolls/2022/2022-Week%2007.md)

#### Observations and Notes (Updated 10/9/2022)

* No notes for this week :)

#### Predictions (Updated 10/9/2022)

Week 7 Predictions: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/master/CFBPoll/PreviousPolls/2022/Predictions/2022-Week%2007.md)

Week 6 Results [here](https://github.com/taylorleprechaun/CFBPollNew/blob/master/CFBPoll/PreviousPolls/2022/Predictions/2022-Week%2006.md):
* Winner: 38 - 19
* ATS: 26 - 31
* O/U: 28 - 29

Season Results:
* Winner: 181 - 92
* ATS: 129 - 143
* O/U: 143 - 129
 
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

Something I noticed across these seasons is that the best teams had a rating above 40 and the worst teams were below 16, so I made a list of them (here: https://github.com/taylorleprechaun/CFBPollNew/blob/master/CFBPoll/Resources/BOAT%20and%20WOAT.xlsx )

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
