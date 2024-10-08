# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS)

### Recent changes

* 9/2/2024: Merged in start of some UI changes which I haven't worked on in idk like 8 months. Also made some fixes to typical early season issues due to incomplete/missing data.
* 9/3/2024: Slight adjustments to Predictions algorithm. Small code adjustments to improve the experience of running everything.

### Rankings (Updated 10/6/2024)

**Week 7 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Oregon | 1.0000 | 5-0
2 | Brigham Young | 0.9789 | 5-0
3 | Texas | 0.9588 | 5-0
4 | Washington State | 0.9504 | 4-1
5 | Texas Tech | 0.9477 | 5-1
6 | Iowa State | 0.9391 | 5-0
7 | Ohio State | 0.9386 | 5-0
8 | Miami FL | 0.9383 | 6-0
9 | Pittsburgh | 0.9364 | 5-0
10 | Indiana | 0.9359 | 6-0
11 | Penn State | 0.9269 | 5-0
12 | Texas A&M | 0.9262 | 5-1
13 | Missouri | 0.9250 | 4-1
14 | Kansas State | 0.9241 | 4-1
15 | Boise State | 0.8999 | 4-1
16 | Alabama | 0.8906 | 4-1
17 | Virginia | 0.8880 | 4-1
18 | Georgia | 0.8840 | 4-1
19 | Illinois | 0.8826 | 4-1
20 | Nebraska | 0.8763 | 5-1
21 | Syracuse | 0.8713 | 4-1
22 | Colorado | 0.8673 | 4-1
23 | Liberty | 0.8652 | 4-0
24 | Mississippi | 0.8643 | 5-1
25 | Washington | 0.8617 | 4-2

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/2024-Week%2007.md)

#### Observations and Notes (Updated 10/6/2024)

* It's a little shocking at first to see the top 10 but being undefeated and playing a hard schedule gets a lot of credit in my rating algorithm. Washington State and Texas Tech may be X-1 but they have two of the hardest schedules played so far (according to my strength of schedule algorithm).

#### Predictions (Updated 10/8/2024)

Week 7 Predictions: ~~Coming Soon~~ Had to evac because of Milton. I'll run these when I'm back but it'll be after games start being played.

Week 6 Results: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/Predictions/2024-Week%2006.md)

Week 6 Results:
* Winner: 34 - 15 (69.4%)
* ATS: 21 - 28 (42.9%)
* O/U: 26 - 23 (53.1%)

Season Results:
* Winner: 172 - 84 (67.2%)
* ATS: 115 - 141 (44.9%)
* O/U: 130 - 126 (50.8%)

2023 Season Results:
* Winner: 507 - 232 (68.6%)
* ATS: 365 - 374 (49.4%)
* O/U: 366 - 373 (49.5%)

2022 Season Results:
* Winner: 485 - 240 (66.9%)
* ATS: 341 - 383 (47.1%)
* O/U: 372 - 352 (51.4%)

### TODO List (Updated 12/5/2023)

1. Tweak/improve/adjust prediction algorithm to a point where I'm happy with it. I found a [site](https://www.thepredictiontracker.com/ncaaresults.php) posted on r/CFB with the results of a bunch of predictive algorithms so I'll definitely use this as some benchmarks when updating my algorithm. As of writing this my outright picks are on the low end, my ATS picks are middle of the pack, and my RMSE is really really bad lol.

2. More print-outs: conference average rating, conference top to bottom rating+ranking, conference ranking, division ranking, etc.

3. Add a UI.  This is currently a command line project.  I want to add a UI with dropdowns for the season and sections for outputs and stuff.
	
4. Add improvements for early season ratings (recruiting info, returning production stats, etc. (not sure where to get this data though))

5. ????

### Misc.

**The Best and Worst of all Time!**

My poll, as of this update, has been run across every season from 2000 through 2022 (that's because sports-reference only goes back to the year 2000) (using my new rating formula, meaning the ratings from all previous posts aren't totally accurate to what you'll see here, but the formula is way better now, trust me)

Something I noticed across these seasons is that the best teams had a rating above 40 and the worst teams were below 16, so I made a list of them [here]( https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/Resources/BOAT%20and%20WOAT.xlsx).

I decided to split up the rankings between pre-CFP and CFP eras.  This was because the teams in the CFP would get little bumps from playing an extra game against an elite-level team.
I'm probably going to have to split the CFP era into 4 and 12 team sections but that's a problem for future me

*New additions for the 2023 season!*

* This year Michigan clocks in with a 42.244 in my poll, placing them at #3 in the Playoff Era
* This year Kent State clocks in with a 15.812 in my poll, placing them at 11th worst in the Playoff Era

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
3 | 2022 | Michigan | 42.244 | 15-0
4 | 2022 | Georgia | 42.124 | 15-0
5 | 2015 | Alabama | 41.615 | 14-1

**The bottom 5 Worst of all Time**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2019 | Akron | 13.370 | 0-12
2 | 2009 | EMU | 13.809 | 0-12
3 | 2004 | UCF | 13.954 | 0-11
4 | 2013 | Miami OH | 13.973 | 0-12
5 | 2006 | FIU | 14.394 | 0-12
