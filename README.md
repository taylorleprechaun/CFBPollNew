# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS)

### Recent changes

* 9/9/2023: Conversion to .Net 6 + a little bit of re-architecting the project to make application layers more distinct
* 9/23/2023: Automate game prediction results

### Rankings (Updated 10/30/2023)

**Week 10 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Ohio State | 1.0000 | 8-0
2 | Florida State | 0.9697 | 8-0
3 | Michigan | 0.9688 | 8-0
4 | Texas | 0.9489 | 7-1
5 | Washington | 0.9390 | 8-0
6 | James Madison | 0.9374 | 8-0
7 | Mississippi | 0.9350 | 7-1
8 | Oklahoma | 0.9267 | 7-1
9 | Alabama | 0.9266 | 7-1
10 | Georgia | 0.9229 | 8-0
11 | Penn State | 0.9190 | 7-1
12 | Louisville | 0.9180 | 7-1
13 | Missouri | 0.9056 | 7-1
14 | Oregon | 0.9032 | 7-1
15 | Liberty | 0.8922 | 8-0
16 | Air Force | 0.8907 | 8-0
17 | Notre Dame | 0.8890 | 7-2
18 | Utah | 0.8854 | 6-2
19 | Louisiana State | 0.8752 | 6-2
20 | Kansas | 0.8636 | 6-2
21 | Tulane | 0.8617 | 7-1
22 | Kansas State | 0.8582 | 6-2
23 | Oregon State | 0.8532 | 6-2
24 | UCLA | 0.8490 | 6-2
25 | Tennessee | 0.8471 | 6-2


Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/2023-Week%2010.md)

#### Observations and Notes (Updated 10/30/2023)

* Go Gata!

#### Predictions (Updated 10/30/2023)

Week 10 Predictions: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/Predictions/2023-Week%2010.md)

Week 09 Results [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/Predictions/2023-Week%2009.md):
* Winner: 38 - 16 (70.4%)
* ATS: 28 - 26 (51.9%)
* O/U: 16 - 38 (29.6%) (yikes)

Season Results:
* Winner: 296 - 135 (68.7%)
* ATS: 214 - 217 (49.7%)
* O/U: 209 - 222 (48.5%)

2022 Season Results:
* Winner: 485 - 240 (66.9%)
* ATS: 341 - 383 (47.1%)
* O/U: 372 - 352 (51.4%)
 
### TODO List (Updated 9/23/2023)

1. Tweak/improve/adjust prediction algorithm to a point where I'm happy with it. After the 2022 season (where I ran it for every game for the first time) I noticed some trends/patterns in the predictions which has given me some ideas to improve it.

2. More print-outs: conference average rating, conference top to bottom rating+ranking, conference ranking, division ranking, etc.

3. Add a UI.  This is currently a command line project.  I want to add a UI with dropdowns for the season and sections for outputs and stuff.
	
4. Add improvements for early season ratings (recruiting info, returning production stats, etc. (not sure where to get this data though))

5. ????

### Misc.

**The Best and Worst of all Time!**

My poll, as of this update, has been run across every season from 2000 through 2022 (that's because sports-reference only goes back to the year 2000) (using my new rating formula, meaning the ratings from all previous posts aren't totally accurate to what you'll see here, but the formula is way better now, trust me)

Something I noticed across these seasons is that the best teams had a rating above 40 and the worst teams were below 16, so I made a list of them [here]( https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/Resources/BOAT%20and%20WOAT.xlsx).

I decided to split up the rankings between pre-CFP and CFP eras.  This was because the teams in the CFP would get little bumps from playing an extra game against an elite-level team.

*New additions for the 2022 season!*

* This year Georgia clocks in with a 42.124 in my poll, placing them at #3 in the Playoff Era
* No teams had a rating less than 16.  So no new additions.  The worst team of the season was Massachusetts with a rating of 17.236

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
3 | 2022 | Georgia | 42.124 | 15-0
4 | 2015 | Alabama | 41.615 | 14-1
5 | 2016 | Alabama | 41.061 | 14-1

**The bottom 5 Worst of all Time**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2019 | Akron | 13.370 | 0-12
2 | 2009 | EMU | 13.809 | 0-12
3 | 2004 | UCF | 13.954 | 0-11
4 | 2013 | Miami OH | 13.973 | 0-12
5 | 2006 | FIU | 14.394 | 0-12
