# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS)

### Recent changes

* 9/9/2023: Conversion to .Net 6 + a little bit of re-architecting the project to make application layers more distinct
* 9/23/2023: Automate game prediction results

### Rankings (Updated 11/12/2023)

**Week 12 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Ohio State | 1.0000 | 10-0
2 | Michigan | 0.9906 | 10-0
3 | Washington | 0.9887 | 10-0
4 | Georgia | 0.9887 | 10-0
5 | Florida State | 0.9866 | 10-0
6 | Alabama | 0.9647 | 9-1
7 | Texas | 0.9607 | 9-1
8 | Oregon | 0.9441 | 9-1
9 | Penn State | 0.9349 | 8-2
10 | James Madison | 0.9306 | 10-0
11 | Mississippi | 0.9304 | 8-2
12 | Louisville | 0.9239 | 9-1
13 | Missouri | 0.9167 | 8-2
14 | Oklahoma | 0.9112 | 8-2
15 | Liberty | 0.9061 | 10-0
16 | Louisiana State | 0.8820 | 7-3
17 | Tulane | 0.8718 | 9-1
18 | Iowa | 0.8664 | 8-2
19 | Oregon State | 0.8623 | 8-2
20 | Utah | 0.8587 | 7-3
21 | Kansas State | 0.8582 | 7-3
22 | Troy | 0.8573 | 8-2
23 | North Carolina | 0.8561 | 8-2
24 | Notre Dame | 0.8546 | 7-3
25 | Kansas | 0.8444 | 7-3

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/2023-Week%2012.md)

#### Observations and Notes (Updated 10/30/2023)

* Go Gata!

#### Predictions (Updated 11/12/2023)

Week 12 Predictions: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/Predictions/2023-Week%2012.md)

Week 11 Results [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/Predictions/2023-Week%2011.md):
* Winner: 45 - 19 (70.3%)
* ATS: 28 - 36 (43.8%)
* O/U: 34 - 30 (53.1%)

Season Results:
* Winner: 381 - 176 (68.4)
* ATS: 273 - 284 (49.0%)
* O/U: 269 - 288 (48.3%)

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
