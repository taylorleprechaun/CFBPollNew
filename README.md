# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS)

### Recent changes

* 9/9/2023: Conversion to .Net 6 + a little bit of re-architecting the project to make application layers more distinct
* 9/23/2023: Automate game prediction results

### Rankings (Updated 11/26/2023)

**Week 14 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Michigan | 1.0000 | 12-0
2 | Washington | 0.9980 | 12-0
3 | Georgia | 0.9979 | 12-0
4 | Florida State | 0.9853 | 12-0
5 | Alabama | 0.9841 | 11-1
6 | Texas | 0.9736 | 11-1
7 | Ohio State | 0.9730 | 11-1
8 | Oregon | 0.9511 | 11-1
9 | Penn State | 0.9396 | 10-2
10 | Mississippi | 0.9282 | 10-2
11 | Oklahoma | 0.9244 | 10-2
12 | Missouri | 0.9229 | 10-2
13 | Louisiana State | 0.9087 | 9-3
14 | James Madison | 0.9037 | 11-1
15 | Liberty | 0.9028 | 12-0
16 | Louisville | 0.8939 | 10-2
17 | Tulane | 0.8924 | 11-1
18 | Iowa | 0.8784 | 10-2
19 | North Carolina State | 0.8608 | 9-3
20 | Troy | 0.8550 | 10-2
21 | Notre Dame | 0.8549 | 9-3
22 | Toledo | 0.8491 | 11-1
23 | Kansas State | 0.8464 | 8-4
24 | Oklahoma State | 0.8449 | 9-3
25 | Arizona | 0.8387 | 9-3

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/2023-Week%2014.md)

#### Observations and Notes (Updated 11/26/2023)

* As with previous years I ran some CCG scenarios by plugging in some dummy scores and simulating all the combinations of power conference championship game winners (since those were the only results that affected the top of the poll). You can see a table of the results below. The gist of it is that 5 teams control their own destiny (Georgia, Washington, Michigan, Florida State, Alabama) and 3 need help (Texas, Ohio State, Oregon). For the full output refer to: [combinations](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/2023-Week%2014%20Scenarios.xlsx)

Team | In | Out
---|---|---
Georgia | 24 | 8
Washington | 20 | 12
Michigan | 17 | 15
Florida State | 16 | 16
Alabama | 16 | 16
Texas | 14 | 18
Ohio State | 13 | 19
Oregon | 8 | 24

#### Predictions (Updated 11/27/2023)

Week 14 Predictions (updated for MWC) (plus Army-Navy): [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/Predictions/2023-Week%2014.md)

Week 13 Results [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2023/Predictions/2023-Week%2013.md):
* Winner: 51 - 14 (78.5%)
* ATS: 33 - 32 (50.8%)
* O/U: 32 - 33 (49.2%)

Season Results:
* Winner: 481 - 205 (70.1%)
* ATS: 338 - 348 (49.3%)
* O/U: 335 - 351 (48.8%)

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
