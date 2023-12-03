# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS)

### Recent changes

* 9/9/2023: Conversion to .Net 6 + a little bit of re-architecting the project to make application layers more distinct
* 9/23/2023: Automate game prediction results

### Rankings (Updated 12/23/2023)

**Week 15 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Washington | 1.0000 | 13-0
2 | Michigan | 0.9972 | 13-0
3 | Alabama | 0.9926 | 12-1
4 | Florida State | 0.9860 | 13-0
5 | Texas | 0.9742 | 12-1
6 | Ohio State | 0.9632 | 11-1
7 | Georgia | 0.9605 | 12-1
8 | Penn State | 0.9288 | 10-2
9 | Oregon | 0.9225 | 11-2
10 | Mississippi | 0.9165 | 10-2
11 | Oklahoma | 0.9162 | 10-2
12 | Missouri | 0.9103 | 10-2
13 | Liberty | 0.9032 | 13-0
14 | Louisiana State | 0.9020 | 9-3
15 | James Madison | 0.8930 | 11-1
16 | Louisville | 0.8673 | 10-3
17 | Tulane | 0.8581 | 11-2
18 | Troy | 0.8565 | 11-2
19 | Iowa | 0.8504 | 10-3
20 | North Carolina State | 0.8490 | 9-3
21 | Notre Dame | 0.8436 | 9-3
22 | SMU | 0.8434 | 11-2
23 | Kansas State | 0.8383 | 8-4
24 | Arizona | 0.8308 | 9-3
25 | Clemson | 0.8273 | 8-4

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/2023-Week%2015%20CCG.md)

#### Observations and Notes (Updated 12/3/2023)

* Just I previewed in the [scenarios](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/2023-Week%2014%20Scenarios.xlsx) from last week, with the teams that won the top four shakes out to be: Washington, Michigan, Alabama, and Florida State. Looking at the rating calculations the reason mostly comes down to strength of schedule. Alabama's raw SOS is 8th and weighted SOS is 5th, Texas' are 29th and 21st, and no one else in the top 10 is in the top 30 for either metric. For my own personal rankings, I went with Michigan, Washington, Texas, and Florida State. Even as a certified hater I can't leave out an undefeated Power conference team from the playoff despite them playing like dog water without their starting QB.

#### Predictions (Updated 12/3/2023)

Week 14 Predictions (plus Army-Navy): [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/Predictions/2023-Week%2014.md)

Week 14 Results (minus Army-Navy) [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/Predictions/2023-Week%2014.md):
* Winner: 6 - 4 (60.0%)
* ATS: 7 - 3 (70.0%)
* O/U: 3 - 7 (30.0%)

Season Results:
* Winner: 487 - 209 (70.0%)
* ATS: 345 - 351 (49.6%)
* O/U: 338 - 358 (48.6%)

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
