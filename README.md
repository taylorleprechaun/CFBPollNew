# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS)

### Recent changes

* 9/2/2024: Merged in start of some UI changes which I haven't worked on in idk like 8 months. Also made some fixes to typical early season issues due to incomplete/missing data.
* 9/3/2024: Slight adjustments to Predictions algorithm. Small code adjustments to improve the experience of running everything.

### Rankings (Updated 9/29/2024)

**Week 6 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Alabama | 1.0000 | 4-0
2 | Missouri | 0.9780 | 4-0
3 | Ohio State | 0.9778 | 4-0
4 | Penn State | 0.9706 | 4-0
5 | Oregon | 0.9639 | 4-0
6 | Iowa State | 0.9616 | 4-0
7 | Texas | 0.9603 | 5-0
8 | Tennessee | 0.9591 | 4-0
9 | Brigham Young | 0.9518 | 5-0
10 | Rutgers | 0.9445 | 4-0
11 | Kansas State | 0.9365 | 4-1
12 | Duke | 0.9296 | 5-0
13 | Pittsburgh | 0.9251 | 4-0
14 | Washington State | 0.9105 | 4-1
15 | Texas Tech | 0.9041 | 4-1
16 | Michigan | 0.9025 | 4-1
17 | James Madison | 0.9023 | 4-0
18 | UNLV | 0.9020 | 4-0
19 | Miami FL | 0.9017 | 5-0
20 | Indiana | 0.8938 | 5-0
21 | Army | 0.8786 | 4-0
22 | Boston College | 0.8729 | 4-1
23 | Liberty | 0.8675 | 4-0
24 | Colorado | 0.8631 | 4-1
25 | Navy | 0.8586 | 4-0

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/2024-Week%2006.md)

#### Observations and Notes (Updated 9/29/2024)

* Wow Georgia just plummeted after that loss. From #3 to #27 is kinda crazy. Looking into why, it has to do with the way my poll rates teams. Anyone who's been here since the beginning will know that I reward more than anything else winning your games and doing so against harder competition. Winning your games is basically just straight winning percentage and the other 1-loss teams ahead of them have all played one more game which does make a slight difference. If they were 4-1 instead of 3-1 they'd be around #20-ish but that's still a huge drop. The real difference maker is strength of schedule. They're SoS to this point in the season is significantly lower than the 1-loss teams ahead of them and is killing them in the rankings. This will resolve itself as the season goes on and more data points get made.

#### Predictions (Updated 9/29/2024)

Week 6 Predictions: Coming Soon

Week 5 Results: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/Predictions/2024-Week%2005.md)

Week 5 Results:
* Winner: 38 - 15 (71.7%)
* ATS: 28 - 25 (52.8%)
* O/U: 26 - 27 (49.1%)

Season Results:
* Winner: 138 - 69 (66.7%)
* ATS: 94 - 113 (45.4%)
* O/U: 104 - 103 (50.2%)

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
